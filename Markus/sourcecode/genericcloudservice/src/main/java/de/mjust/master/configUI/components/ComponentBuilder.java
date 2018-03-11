package de.mjust.master.configUI.components;

import com.vaadin.addon.charts.Chart;
import com.vaadin.addon.charts.model.*;
import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.ui.Component;
import com.vaadin.ui.Grid;
import de.mjust.master.model.DataObject;

import java.util.ArrayList;
import java.util.Set;

public class ComponentBuilder implements IComponentObserver {

    private boolean isBarInConfigureMode = false;
    private Chart chart;

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
        isBarInConfigureMode = true;
        chart = new Chart(ChartType.BAR);
        Configuration conf = chart.getConfiguration();

        conf.setTitle("Bar chart");
        conf.setSubTitle("Plant 1");

        XAxis x = new XAxis();
        x.setCategories("A", "B");
        x.setTitle((String) "Plants");
        conf.addxAxis(x);

        YAxis y = new YAxis();
        y.setMin(0);
        AxisTitle title = new AxisTitle("Value");
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

        return configureChart(selectedFields);
    }

    private Component configureChart(Set<DataObject> selectedFields) {
        Configuration conf = chart.getConfiguration();
        conf.setSeries(getSeriesFromSelectedFields(selectedFields));
        chart.drawChart(conf);

        return chart;
    }

    private ArrayList<Series> getSeriesFromSelectedFields(Set<DataObject> selectedFields) {
        ArrayList<Series> series = new ArrayList<>();
        for (DataObject dataObject : selectedFields){
            if(dataObject.getValue() instanceof ArrayList){
                if(((ArrayList) dataObject.getValue()).get(0) instanceof Number) {
                    series.add(new ListSeries(dataObject.getKey(), (ArrayList<Number>) dataObject.getValue()));
                }
            }
            if(dataObject.getValue() instanceof Number)
            series.add(new ListSeries(dataObject.getKey(), (Number) dataObject.getValue()));
        }
        return series;
    }

    @Override
    public void update(Set<DataObject> selectedFields) {
        if(isBarInConfigureMode) {
            configureChart(selectedFields);
        }
    }
}
