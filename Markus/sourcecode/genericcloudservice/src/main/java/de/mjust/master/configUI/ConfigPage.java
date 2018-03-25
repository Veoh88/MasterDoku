package de.mjust.master.configUI;


import com.vaadin.annotations.Theme;
import com.vaadin.data.HasValue;
import com.vaadin.navigator.View;
import com.vaadin.ui.*;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.configUI.manager.ViewRegistry;
import de.mjust.master.model.DataObject;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.UserRegistry;
import de.mjust.master.model.dbmodel.User;
import de.mjust.master.model.dbmodel.UserRole;
import de.mjust.master.provider.IDataSourceProvider;
import de.mjust.master.provider.UserProvider;
import de.mjust.master.provider.UserRoleProvider;

import java.util.*;

@Theme("mytheme")
public class ConfigPage extends VerticalLayout implements View {

    private Button saveButton;

    private ViewConfigManager viewConfigManager;
    private ViewRegistry viewRegistry;

    private IDataSourceProvider dataSourceProvider;
    private UserProvider userProvider;
    private UserRoleProvider userRoleProvider;
    private UserRegistry userRegistry;
    private ComponentBuilder componentBuilder;
    private final ComboBox<IDataSource> comboBox;
    private final ComboBox<User> users;
    private final ComboBox<UserRole> userRoles;


    public ConfigPage(ViewConfigManager viewConfigManager, IDataSourceProvider dataSourceProvider, UserProvider userProvider, UserRoleProvider userRoleProvider, UserRegistry userRegistry, ComponentBuilder componentBuilder) {
        this.viewConfigManager = viewConfigManager;
        this.dataSourceProvider = dataSourceProvider;
        this.userProvider = userProvider;
        this.userRoleProvider = userRoleProvider;
        this.userRegistry = userRegistry;
        this.componentBuilder = componentBuilder;
        this.viewRegistry = ViewRegistry.getInstance();
        users = new ComboBox<>("Select user");
        users.setItemCaptionGenerator(User::getName);
        users.addValueChangeListener(x -> initUserView(x));
        userRoles = new ComboBox<>("Select user role");
        userRoles.setItemCaptionGenerator(UserRole::getName);
        comboBox = new ComboBox<>("Select Data Source");
        setComboBoxItems();
        comboBox.setPlaceholder("Choose data source");
        comboBox.setItemCaptionGenerator(IDataSource::getSourceName);
        Button addButton = new Button("Add Source");
        addButton.addClickListener(e -> {
            if (comboBox.getSelectedItem().isPresent()) {
                this.viewConfigManager.addSelectedDataSource(comboBox.getSelectedItem().get());
                performDataSearch(comboBox.getSelectedItem());
            }
        });
        setWidth("500px");
        setStyleName("layout-with-borders");
        addComponents(users, userRoles, comboBox, addButton);
    }

    private void initUserView(HasValue.ValueChangeEvent<User> x) {
        if(this.userRegistry.userHasComponents(x.getValue())){
            this.viewRegistry.getUserViewConfig().initUserComponents(userRegistry.getUserMappings(x.getValue()));
        }
        else {
            this.viewRegistry.getUserViewConfig().setBlankView(x.getValue());
            this.componentBuilder.removeCurrentComponents();
        }
    }

    private void setComboBoxItems() {
        comboBox.setItems(this.dataSourceProvider.getDataSources());
        users.setItems(this.userProvider.getUsers());
        userRoles.setItems(this.userRoleProvider.getRoles());
    }

    public void enterView() {
        this.setComboBoxItems();
    }

    private void performDataSearch(Optional<IDataSource> selectedItem) {
        HorizontalLayout horizontalLayout = new HorizontalLayout();
        horizontalLayout.setWidth("100%");
        horizontalLayout.setSpacing(true);
        Button removeButton = new Button("remove Source");
        Collection<DataObject> dataObjects = selectedItem.get().getDataObjects();
        if (dataObjects == null) {
            Notification.show("Data couldn't be fetched", Notification.Type.ERROR_MESSAGE);
        } else {
            CheckBoxGroup<DataObject> checkBoxGroup = new CheckBoxGroup<DataObject>(selectedItem.get().getSourceName(), dataObjects);
            checkBoxGroup.setItemCaptionGenerator(item -> item.getKeyWithType());
            checkBoxGroup.addValueChangeListener(e -> {
                computeCheckboxEvent(e, dataObjects);
            });
            removeButton.addClickListener(e -> {
                this.viewConfigManager.removeAllFromSelectedFields(
                        checkBoxGroup.getValue());
                this.saveButton.setEnabled(!viewConfigManager.getSelectedFields().isEmpty());
                this.viewConfigManager.removeSelectedDataSource(comboBox.getSelectedItem().get());
                removeComponent(horizontalLayout);
            });
            horizontalLayout.addComponents(checkBoxGroup, removeButton);
            horizontalLayout.setComponentAlignment(removeButton, Alignment.TOP_RIGHT);

            if (this.saveButton == null) {
                initAddTableButton(horizontalLayout);
            } else {
                removeComponent(saveButton);
                addComponents(horizontalLayout, saveButton);
            }
        }
    }

    private void computeCheckboxEvent(HasValue.ValueChangeEvent<Set<DataObject>> e, Collection<DataObject> dataObjects) {
        for (DataObject object : dataObjects) {
            if (e.getValue().contains(object)) {
                this.viewConfigManager.addSelectedField(object);
            } else {
                this.viewConfigManager.removeSelectedField(object);
            }
        }
        ;
        this.saveButton.setEnabled(!this.viewConfigManager.getSelectedFields().isEmpty());
    }

    private void initAddTableButton(HorizontalLayout horizontalLayout) {
        this.saveButton = new Button("Save view");
        this.saveButton.setEnabled(!this.viewConfigManager.getSelectedFields().isEmpty());
        this.saveButton.addClickListener(e -> {
            this.componentBuilder.saveComponentsInRegistry(this.userRegistry, this.users.getValue());
        });
        addComponents(horizontalLayout, this.saveButton);
    }

}
