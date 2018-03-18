package de.mjust.master.configUI.forms;

import com.vaadin.shared.ui.ContentMode;
import com.vaadin.ui.Button;
import com.vaadin.ui.FormLayout;
import com.vaadin.ui.Label;
import com.vaadin.ui.TextField;
import de.mjust.master.configUI.components.ComponentBuilder;

public class BarChartForm extends FormLayout implements IComponentConfigForm {

    private ComponentBuilder componentBuilder;
    private TextField titleField;
    private TextField subtitleField;
    private TextField ylabelField;
    private TextField xLabelField;

    public BarChartForm(ComponentBuilder componentBuilder){
        this.componentBuilder = componentBuilder;
        Label titleLabel = new Label("<h2>Configure bar chart</h2>", ContentMode.HTML);
        addComponent(titleLabel);
        initForm();
    }

    private void initForm() {
        titleField = new TextField("Title");
        addComponent(titleField);

        subtitleField = new TextField("Subtitle");
        addComponent(subtitleField);

        ylabelField = new TextField("Y-Label");
        addComponent(ylabelField);

        xLabelField = new TextField("X-Label");
        addComponent(xLabelField);

        Button saveButton = new Button("Save");
        saveButton.addClickListener(x -> updatedBarChart());
        addComponent(saveButton);
    }

    private void updatedBarChart() {
        componentBuilder.setBarChartTitle(titleField.getValue());
        componentBuilder.setBarChartSubTitle(subtitleField.getValue());
        componentBuilder.setBarChartYLabel(ylabelField.getValue());
        componentBuilder.setBarChartXLabel(xLabelField.getValue());
        componentBuilder.drawChart();
    }
}
