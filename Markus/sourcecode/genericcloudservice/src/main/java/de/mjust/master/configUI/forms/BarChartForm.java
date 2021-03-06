package de.mjust.master.configUI.forms;

import com.vaadin.addon.charts.Chart;
import com.vaadin.addon.charts.model.ChartConfiguration;
import com.vaadin.addon.charts.model.Configuration;
import com.vaadin.addon.charts.model.ListSeries;
import com.vaadin.addon.charts.model.Series;
import com.vaadin.data.HasValue;
import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.shared.ui.ContentMode;
import com.vaadin.ui.*;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.manager.ViewConfigManager;

import java.util.Collection;

public class BarChartForm extends GridLayout implements IComponentConfigForm {

    private ComponentBuilder componentBuilder;
    private ViewConfigManager viewConfigManager;
    private TextField titleField;
    private TextField subtitleField;
    private TextField ylabelField;
    private TextField xLabelField;
    private TextField yMinField;
    private TextField yMaxField;
    private TextField xIndexField;
    private TextField updateInterval;
    private CheckBox intervalCheckbox;

    public BarChartForm(ComponentBuilder componentBuilder, ViewConfigManager viewConfigManager){
        super(4,5);
        this.componentBuilder = componentBuilder;
        this.viewConfigManager = viewConfigManager;
        Label titleLabel = new Label("<h2>Configure bar chart</h2>", ContentMode.HTML);
        addComponent(titleLabel, 0,0, 3,0);
        setSizeFull();
        initForm();
    }

    private void initForm() {
        initLabelFields();
    }

    private void initSeriesDetails(Series value) {
    }


    private void initLabelFields() {
        titleField = new TextField("Title");
        addComponent(titleField,0,1);

        subtitleField = new TextField("Subtitle");
        addComponent(subtitleField, 0,2);

        ylabelField = new TextField("Y-Label");
        addComponent(ylabelField, 0,3);

        xLabelField = new TextField("X-Label");
        addComponent(xLabelField,0,4);

        yMinField = new TextField("Min y-value");
        addComponent(yMinField,1,1);

        yMaxField = new TextField("Max y-value");
        addComponent(yMaxField,1,2);

        xIndexField = new TextField("X-labels (comma separated)");
        addComponent(xIndexField,1,3);

        CheckBox intervalCheckbox = new CheckBox("Live data?");
        intervalCheckbox.addValueChangeListener(x -> addUpdateIntervalInput(x));
        addComponent(intervalCheckbox, 2, 1);

        Button saveButton = new Button("Save");
        saveButton.addClickListener(x -> updatedBarChart());
        addComponent(saveButton,2,4);
    }

    private void addUpdateIntervalInput(HasValue.ValueChangeEvent<Boolean> x) {
        if(x.getValue()){
            this.updateInterval = new TextField("Update interval in seconds:");
            addComponent(updateInterval, 2,2);
        }
        else{
            removeComponent(updateInterval);
        }

    }

    private void updatedBarChart() {
        componentBuilder.setBarChartTitle(titleField.getValue());
        componentBuilder.setBarChartSubTitle(subtitleField.getValue());
        componentBuilder.setBarChartYLabel(ylabelField.getValue());
        componentBuilder.setBarChartXLabel(xLabelField.getValue());
        componentBuilder.setBarChartYMin(yMinField.getValue());
        componentBuilder.setBarChartYMax(yMaxField.getValue());
        componentBuilder.setBarChartXIndexes(xIndexField.getValue());
        componentBuilder.drawChart();
    }
}
