package de.mjust.master.configUI;


import com.vaadin.annotations.Theme;
import com.vaadin.data.HasValue;
import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.navigator.View;
import com.vaadin.ui.*;
import de.mjust.master.model.DataObject;
import de.mjust.master.model.DataSource;
import de.mjust.master.model.IDataSource;

import java.util.*;

@Theme("mytheme")
public class SubPage extends VerticalLayout implements View {

    private Button addButton;
    private Set<DataObject> selectedFields = new HashSet<>();


    public SubPage() {

        List<IDataSource> sampleDataSources = new ArrayList<>();
        sampleDataSources.add(new DataSource("Source1"));
        sampleDataSources.add(new DataSource("Source2"));

        ComboBox<IDataSource> comboBox = new ComboBox<>("Select Data Source", sampleDataSources);
        comboBox.setPlaceholder("Choose data source");
        comboBox.setItemCaptionGenerator(IDataSource::getSourceName);
        Button addButton = new Button("Add Source");
        addButton.addClickListener(e -> {
            if (comboBox.getSelectedItem().isPresent()) {
                performDataSearch(comboBox.getSelectedItem());
            }
        });
        addComponents(comboBox, addButton);
    }

    private void performDataSearch(Optional<IDataSource> selectedItem) {

        VerticalLayout verticalLayout = new VerticalLayout();
        HorizontalLayout horizontalLayout = new HorizontalLayout();
        Button removeButton = new Button("remove Source");

        Collection<DataObject> dataObjects = selectedItem.get().getDataObjects();
        CheckBoxGroup<DataObject> checkBoxGroup = new CheckBoxGroup<DataObject>(selectedItem.get().getSourceName(), dataObjects);
        checkBoxGroup.setItemCaptionGenerator(item -> item.getDescriptionWithType());
        checkBoxGroup.addValueChangeListener(e -> {
            computeCheckboxEvent(e, dataObjects);
        });
            removeButton.addClickListener(e -> {
                this.selectedFields.removeAll(checkBoxGroup.getValue());
                this.addButton.setEnabled(!this.selectedFields.isEmpty());
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
                this.selectedFields.add(object);
            }
            else{
                this.selectedFields.remove(object);
            }
        };
        this.addButton.setEnabled(!this.selectedFields.isEmpty());
    }

    private void initAddTableButton (HorizontalLayout horizontalLayout){
            this.addButton = new Button("Add Table");
            this.addButton.setEnabled(!this.selectedFields.isEmpty());
            this.addButton.addClickListener(e -> {
                Grid<DataObject> grid = new Grid<>();
                grid.setDataProvider(new ListDataProvider<DataObject>(this.selectedFields));
                grid.addColumn(DataObject::getDescription)
                        .setId("DataFieldDescription")
                        .setCaption("DataField");
                addComponent(grid);
            });
            addComponents(horizontalLayout, this.addButton);
        }
    }
