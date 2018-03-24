package de.mjust.master.configUI.components;

import com.vaadin.addon.charts.Chart;
import com.vaadin.addon.charts.model.*;
import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.ui.Component;
import com.vaadin.ui.Grid;
import de.mjust.master.model.DataObject;
import de.mjust.master.model.UserComponent;
import de.mjust.master.model.UserComponentMap;
import de.mjust.master.model.UserRegistry;
import de.mjust.master.model.dbmodel.User;

import java.util.*;

public class ComponentBuilder implements ISelectedFieldsObserver {

    private ComponentRegistry componentRegistry;
    private Chart chart;
    private Collection<UUID> currentComponents;
    private Collection<ISelectedComponentObserver> componentObserverList;
    private UUID activeComponent;

    public ComponentBuilder() {
        this.componentObserverList = new ArrayList<>();
        this.componentRegistry = new ComponentRegistry();
        this.currentComponents = new ArrayList<>();
    }

    public Component buildTable(Set<DataObject> selectedFields) {

        Grid<DataObject> grid = new Grid<>();
        grid.setDataProvider(new ListDataProvider<>(selectedFields));
        grid.addColumn(DataObject::getKey)
                .setId("DataFieldDescription")
                .setCaption("Key");
        grid.addColumn(DataObject::getValue)
                .setId("DataFieldValue")
                .setCaption("Value");
        grid.setSizeFull();
        return grid;
    }

    public Component buildBarChart(Set<DataObject> selectedFields) {
        chart = new Chart(ChartType.BAR);
        chart.setHeight("400px");
        chart.setWidth("500px");

        Configuration conf = chart.getConfiguration();

        conf.setTitle("Bar chart title");
        conf.setSubTitle("Bar chart subtitle");

        XAxis x = new XAxis();
        x.setCategories("A", "B");
        x.setTitle((String) "X-Axis");
        conf.addxAxis(x);

        YAxis y = new YAxis();
        y.setMin(0);
        AxisTitle title = new AxisTitle("Y-Axis");
        title.setAlign(VerticalAlign.MIDDLE);
        y.setTitle(title);
        conf.addyAxis(y);
        Tooltip tooltip = new Tooltip();
        tooltip.setFormatter("this.series.name +': '+ this.y");
        conf.setTooltip(tooltip);

        PlotOptionsBar plot = new PlotOptionsBar();
        plot.setDataLabels(new DataLabels(true));
        conf.setPlotOptions(plot);


        conf.disableCredits();
        registerChart(selectedFields);

        return configureBarChart(selectedFields);
    }

    public Component buildPieChart(Set<DataObject> selectedFields) {
        chart = new Chart(ChartType.PIE);
        chart.setHeight("400px");
        chart.setWidth("500px");

        Configuration conf = chart.getConfiguration();

        conf.setTitle("Pie chart");
        conf.setSubTitle("Plant 1");

        Tooltip tooltip = new Tooltip();
        tooltip.setFormatter("this.series.name +': '+ this.y");
        conf.setTooltip(tooltip);

        PlotOptionsBar plot = new PlotOptionsBar();
        plot.setDataLabels(new DataLabels(true));
        conf.setPlotOptions(plot);


        conf.disableCredits();
        registerChart(selectedFields);

        return configurePieChart(selectedFields);
    }

    private Component configureBarChart(Set<DataObject> selectedFields) {
        Configuration conf = chart.getConfiguration();
        conf.setSeries(getMultipleSeriesFromSelectedFields(selectedFields));
        chart.drawChart(conf);
        notifyComponentChanged();
        return chart;
    }

    private Component configurePieChart(Set<DataObject> selectedFields) {
        Configuration conf = chart.getConfiguration();
        conf.setSeries(getSingleSeriesFromSelectedFields(selectedFields));
        chart.drawChart(conf);
        return chart;
    }

    private void registerChart(Set<DataObject> selectedFields) {
        UUID chartUUID = this.componentRegistry.addComponent(chart, selectedFields);
        this.activeComponent = chartUUID;
        this.currentComponents.add(chartUUID);
        chart.addChartClickListener(x -> {
            this.activeComponent = chartUUID;
            notifyComponentChanged();
        });
    }

    private void notifyComponentChanged() {
        componentObserverList.stream().forEach(x -> x.update());
    }

    private ArrayList<Series> getMultipleSeriesFromSelectedFields(Set<DataObject> selectedFields) {
        ArrayList<Series> series = new ArrayList<>();
        for (DataObject dataObject : selectedFields) {
            if (dataObject.getValue() instanceof ArrayList) {
                if (((ArrayList) dataObject.getValue()).get(0) instanceof Number) {
                    series.add(new ListSeries(dataObject.getKey(), (ArrayList<Number>) dataObject.getValue()));
                }
            }
            if (dataObject.getValue() instanceof Number)
                series.add(new ListSeries(dataObject.getKey(), (Number) dataObject.getValue()));
        }
        return series;
    }

    private Series getSingleSeriesFromSelectedFields(Set<DataObject> selectedFields) {
        DataSeries series = new DataSeries();
        for (DataObject dataObject : selectedFields) {
//            if(dataObject.getValue() instanceof ArrayList){

//            }
            if (dataObject.getValue() instanceof Number)
                series.add(new DataSeriesItem(dataObject.getKey(), (Number) dataObject.getValue()));
        }
        return series;
    }

    @Override
    public void update(Set<DataObject> selectedFields) {
        Component currentComponent = this.componentRegistry.getComponentByUUID(this.activeComponent);
        if (currentComponent instanceof Chart) {
            Chart chart = (Chart) currentComponent;
            if (chart.getConfiguration().getChart().getType() == ChartType.BAR) {
                this.chart = chart;
                configureBarChart(selectedFields);
            }
            if (chart.getConfiguration().getChart().getType() == ChartType.PIE) {
                this.chart = chart;
                configurePieChart(selectedFields);
            }
        }

    }

    public Component getCurrentEditingComponent() {
        return chart;
    }

    public void setBarChartTitle(String titleField) {
        chart.getConfiguration().setTitle(titleField);
    }

    public void setBarChartSubTitle(String subtitleField) {
        chart.getConfiguration().setSubTitle(subtitleField);

    }

    public void setBarChartYLabel(String ylabelField) {
        chart.getConfiguration().getyAxis().setTitle(ylabelField);
    }

    public void setBarChartXLabel(String xLabelField) {
        chart.getConfiguration().getxAxis().setTitle(xLabelField);
    }

    public void drawChart() {
        chart.drawChart();
    }

    public void registerObserver(ISelectedComponentObserver observer) {
        this.componentObserverList.add(observer);
    }

    public void saveComponentsInRegistry(UserRegistry userRegistry, User currentUser) {
        Collection<UserComponent> userComponents = createComponentDefinitions();
        userRegistry.addUserMapping(currentUser, userComponents);
    }

    private Collection<UserComponent> createComponentDefinitions() {
        Collection<UserComponent> userComponents = new ArrayList<>();
        Set<UUID> uuidKeys = componentRegistry.getUUIDs();
        for (UUID uuid : uuidKeys) {
            Component component = this.componentRegistry.getComponentByUUID(uuid);
            UserComponent userComponent = new UserComponent();
            if (component instanceof Chart) {
                Chart chart = (Chart) component;
                if (chart.getConfiguration().getChart().getType() == ChartType.BAR) {
                    userComponent.setChartType(ChartType.BAR);
                    userComponent.setConfiguration(chart.getConfiguration());
                    userComponent.setChart(true);
                    userComponent.setUuid(uuid);
                    userComponent.setSelectedFields(new HashSet<>(this.componentRegistry.getDataObjectsByUUID(uuid)));
                    userComponents.add(userComponent);
                } else if (chart.getConfiguration().getChart().getType() == ChartType.PIE) {
                    userComponent.setChartType(ChartType.PIE);
                    userComponent.setConfiguration(chart.getConfiguration());
                    userComponent.setChart(true);
                    userComponent.setUuid(uuid);
                    userComponent.setSelectedFields(new HashSet<>(this.componentRegistry.getDataObjectsByUUID(uuid)));
                    userComponents.add(userComponent);
                }
            } else {
                userComponent.setTable(true);
                userComponent.setUuid(uuid);
                userComponent.setSelectedFields(new HashSet<>(this.componentRegistry.getDataObjectsByUUID(uuid)));
                userComponents.add(userComponent);
            }
        }
        return userComponents;
    }

    public void removeCurrentComponents() {
        this.componentRegistry.removeComponents();
    }

    public Collection<Component> buildUserComponents(Collection<UserComponent> userComponents) {
        this.componentRegistry.removeComponents();
        Collection<Component> components = new ArrayList<>();
        for (UserComponent userComponent : userComponents) {
            if (userComponent.isChart()) {
                if (userComponent.getChartType() == ChartType.BAR) {
                    components.add(buildBarChart(userComponent.getSelectedFields()));
                } else if (userComponent.getChartType() == ChartType.PIE) {
                    components.add(buildPieChart(userComponent.getSelectedFields()));
                } else {
                    components.add(buildTable(userComponent.getSelectedFields()));
                }
            }
        }
        return components;
    }
}
