package de.mjust.master.configUI;

import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.navigator.View;
import com.vaadin.server.ThemeResource;
import com.vaadin.shared.ui.ContentMode;
import com.vaadin.ui.*;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.RestDataSource;
import de.mjust.master.provider.IDataSourceProvider;

import java.util.ArrayList;
import java.util.Collection;

public class DataSourceConfigPage extends VerticalLayout implements View {

    private Collection<IDataSource> dataSources;
    private IDataSourceProvider dataSourceProvider;
    private ListDataProvider<IDataSource> sourceListDataProvider;
    private TextField sourceNameField;
    private TextField sourcesUriField;

    public DataSourceConfigPage(IDataSourceProvider dataSourceProvider) {
        this.dataSourceProvider = dataSourceProvider;
        this.dataSources = new ArrayList<>(this.dataSourceProvider.getDataSources());
        createDataSourceOverview();
        createDataSourcesInput();
    }

    public DataSourceConfigPage(){}

    private void createDataSourcesInput() {
        HorizontalLayout newSourcesLayout = new HorizontalLayout();
        sourceNameField = new TextField();
        sourceNameField.setCaption("Source Name");
        sourceNameField.setPlaceholder("Enter Source Name");
        sourceNameField.setMaxLength(30);

        sourcesUriField = new TextField();
        sourcesUriField.setCaption("Source URI");
        sourcesUriField.setPlaceholder("Enter Source URI");
        sourcesUriField.setWidth("100%");

        Button saveButton = new Button("Save");
        saveButton.addClickListener(x -> saveDataSource());
        newSourcesLayout.addComponents(sourceNameField, sourcesUriField, saveButton);
        addComponent(newSourcesLayout);
        newSourcesLayout.setComponentAlignment(saveButton, Alignment.BOTTOM_CENTER);
    }

    private void saveDataSource() {
        String sourceName = sourceNameField.getValue();
        IDataSource dataSource = sourceListDataProvider.getItems().stream().filter(x -> x.getSourceName().equals(sourceName)).findAny().orElse(null);
        if(dataSource == null){
            this.dataSources.add(new RestDataSource(sourceName, sourcesUriField.getValue()));
            dataSourceProvider.setDataSources(this.dataSources);
            sourceListDataProvider.refreshAll();
        }
        else{
            dataSource.setSourceOrigin(sourcesUriField.getValue());
            sourceListDataProvider.refreshAll();
        }

    }

    private void createDataSourceOverview() {
        Label dsLabel = new Label("<h1>Configured DataSources: </h1>", ContentMode.HTML);
        addComponent(dsLabel);
        setComponentAlignment(dsLabel, Alignment.TOP_CENTER);
        createGrid();
    }

    private void createGrid() {
        Grid<IDataSource> grid = new Grid<>();

        sourceListDataProvider = new ListDataProvider<>(this.dataSources);
        grid.setDataProvider(sourceListDataProvider);

        grid.addComponentColumn(x -> new Label(x.getSourceName())).setCaption("Name");
        grid.addComponentColumn(x -> new Label(x.getSourceOrigin())).setCaption("URI");
        grid.addComponentColumn(this::buildEditButton).setCaption("Edit");
        grid.addComponentColumn(this::buidDeleteButton).setCaption("Delete");
        grid.setSizeFull();
        addComponent(grid);
    }

    private Button buidDeleteButton(IDataSource iDataSource) {
        Button deleteButton = new Button("Delete");
        deleteButton.addClickListener(x -> deleteItem(iDataSource));
        deleteButton.setIcon(new ThemeResource("../mytheme/delete.png"), "Delete");
        return deleteButton;
    }

    private void deleteItem(IDataSource iDataSource) {
        this.dataSources.remove(iDataSource);
        sourceListDataProvider.refreshAll();
    }

    private Button buildEditButton(IDataSource iDataSource) {
        Button editButton = new Button("Edit");
        editButton.addClickListener(x -> editItem(iDataSource));
        editButton.setIcon(new ThemeResource("../mytheme/edit.png"), "Edit");
        return editButton;

    }

    private void editItem(IDataSource iDataSource) {
        this.sourceNameField.setValue(iDataSource.getSourceName());
        this.sourcesUriField.setValue(iDataSource.getSourceOrigin());
    }

}
