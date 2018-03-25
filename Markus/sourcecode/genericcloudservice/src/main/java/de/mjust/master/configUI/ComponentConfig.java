package de.mjust.master.configUI;

import com.vaadin.ui.Component;
import com.vaadin.ui.HorizontalLayout;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.components.ComponentType;
import de.mjust.master.configUI.components.ISelectedComponentObserver;
import de.mjust.master.configUI.components.ISelectedFieldsObserver;
import de.mjust.master.configUI.forms.BarChartForm;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.model.DataObject;

import java.util.Collection;
import java.util.Set;

public class ComponentConfig extends HorizontalLayout implements ISelectedComponentObserver {

    private ComponentType type;
    private Collection<DataObject> dataObjects;
    private Component currentEditingComponent;
    private ViewConfigManager viewConfigManager;
    private ComponentBuilder componentBuilder;
    private BarChartForm barChartForm;

    public ComponentConfig(ViewConfigManager viewConfigManager, ComponentBuilder componentBuilder) {
        this.viewConfigManager = viewConfigManager;
        this.componentBuilder = componentBuilder;
        barChartForm = new BarChartForm(componentBuilder, viewConfigManager);
        this.componentBuilder.registerObserver(this);
        setSizeFull();
        getCurrentEditingComponent();
    }

    private void getCurrentEditingComponent() {
        this.currentEditingComponent = this.componentBuilder.getCurrentEditingComponent();
        if(this.currentEditingComponent != null){
            addComponent(barChartForm);
        }
        else{
            removeComponent(barChartForm);
        }
    }

    @Override
    public void update() {
        getCurrentEditingComponent();
    }
}
