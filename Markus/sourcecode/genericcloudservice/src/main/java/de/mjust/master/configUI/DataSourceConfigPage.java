package de.mjust.master.configUI;

import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.navigator.View;
import com.vaadin.ui.*;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.dbmodel.DataSource;
import de.mjust.master.provider.IDataSourceProvider;
import de.mjust.master.provider.MockDataSourcesProvider;

import java.util.ArrayList;
import java.util.Collection;

public class DataSourceConfigPage extends VerticalLayout implements View {

    private Collection<IDataSource> dataSources;
    private IDataSourceProvider dataSourceProvider;
    private ListDataProvider<IDataSource> sourceListDataProvider;

    public DataSourceConfigPage() {
        this.dataSourceProvider = new MockDataSourcesProvider();
        this.dataSources = new ArrayList<>(dataSourceProvider.getDataSources());
        createDataSourceOverview();
        createDataSourcesInput();
    }

    private void createDataSourcesInput() {
        HorizontalLayout newSourcesLayout = new HorizontalLayout();
        TextField sourceNameField = new TextField();
        sourceNameField.setPlaceholder("Enter Source Name");
        sourceNameField.setMaxLength(30);

        TextField sourcesUriField = new TextField();
        sourcesUriField.setPlaceholder("Enter Source URI");

        Button saveButton = new Button("Save");
        newSourcesLayout.addComponents(sourceNameField, sourcesUriField, saveButton);
        addComponent(newSourcesLayout);
    }

    private void createDataSourceOverview() {
        Label dsLabel = new Label("Configured DataSources: ");
        addComponent(dsLabel);
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
        return deleteButton;
    }

    private void deleteItem(IDataSource iDataSource) {
        this.dataSources.remove(iDataSource);
        sourceListDataProvider.refreshAll();
    }

    private Button buildEditButton(IDataSource iDataSource) {
        Button editButton = new Button("Edit");
        return editButton;

    }

}
