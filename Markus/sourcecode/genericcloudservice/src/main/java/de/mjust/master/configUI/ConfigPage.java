package de.mjust.master.configUI;


import com.vaadin.annotations.Theme;
import com.vaadin.data.HasValue;
import com.vaadin.navigator.View;
import com.vaadin.ui.*;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.model.DataObject;
import de.mjust.master.model.IDataSource;
import de.mjust.master.provider.IDataSourceProvider;
import de.mjust.master.provider.DataSourcesProvider;

import java.util.*;

@Theme("mytheme")
public class ConfigPage extends VerticalLayout implements View {

    private Button addButton;

    private ViewConfigManager viewConfigManager;

    private IDataSourceProvider dataSourceProvider;


    public ConfigPage(ViewConfigManager viewConfigManager, IDataSourceProvider dataSourceProvider) {
        this.viewConfigManager = viewConfigManager;
        this.dataSourceProvider = dataSourceProvider;

        ComboBox<IDataSource> comboBox = new ComboBox<>("Select Data Source", this.dataSourceProvider.getDataSources());
        comboBox.setPlaceholder("Choose data source");
        comboBox.setItemCaptionGenerator(IDataSource::getSourceName);
        Button addButton = new Button("Add Source");
        addButton.addClickListener(e -> {
            if (comboBox.getSelectedItem().isPresent()) {
                performDataSearch(comboBox.getSelectedItem());
            }
        });
        setWidth("500px");
        addComponents(comboBox, addButton);
    }

    private void performDataSearch(Optional<IDataSource> selectedItem) {

        VerticalLayout verticalLayout = new VerticalLayout();
        verticalLayout.setWidth("100%");
        HorizontalLayout horizontalLayout = new HorizontalLayout();
        horizontalLayout.setWidth("100%");
        horizontalLayout.setSpacing(true);
        Button removeButton = new Button("remove Source");

        Collection<DataObject> dataObjects = selectedItem.get().getDataObjects();
        CheckBoxGroup<DataObject> checkBoxGroup = new CheckBoxGroup<DataObject>(selectedItem.get().getSourceName(), dataObjects);
        checkBoxGroup.setItemCaptionGenerator(item -> item.getKeyWithType());
        checkBoxGroup.addValueChangeListener(e -> {
            computeCheckboxEvent(e, dataObjects);
        });
            removeButton.addClickListener(e -> {
                this.viewConfigManager.removeAllFromSelectedFields(
                        checkBoxGroup.getValue());
                this.addButton.setEnabled(!viewConfigManager.getSelectedFields().isEmpty());
                removeComponent(horizontalLayout);
            });
            horizontalLayout.addComponents(checkBoxGroup, removeButton);
            verticalLayout.addComponent(horizontalLayout);
            if (this.addButton == null) {
                initAddTableButton(horizontalLayout);
            } else {
                removeComponent(addButton);
                addComponents(horizontalLayout, addButton);
            }
        }

    private void computeCheckboxEvent(HasValue.ValueChangeEvent<Set<DataObject>> e, Collection<DataObject> dataObjects) {
        for(DataObject object : dataObjects){
            if(e.getValue().contains(object)){
                this.viewConfigManager.addSelectedField(object);
            }
            else{
                this.viewConfigManager.removeSelectedField(object);
            }
        };
        this.addButton.setEnabled(!this.viewConfigManager.getSelectedFields().isEmpty());
    }

    private void initAddTableButton (HorizontalLayout horizontalLayout){
            this.addButton = new Button("Add Table");
            this.addButton.setEnabled(!this.viewConfigManager.getSelectedFields().isEmpty());
            this.addButton.addClickListener(e -> {


            });
            addComponents(horizontalLayout, this.addButton);
        }

    }
