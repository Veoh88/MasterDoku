package de.mjust.master.configUI;

import com.vaadin.navigator.View;
import com.vaadin.shared.ui.ContentMode;
import com.vaadin.ui.Alignment;
import com.vaadin.ui.GridLayout;
import com.vaadin.ui.Label;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.provider.IDataSourceProvider;

public class ConfigGrid extends GridLayout implements View{

    private ViewConfigManager viewConfigManager;
    private IDataSourceProvider dataSourceProvider;

    public ConfigGrid(IDataSourceProvider dataSourceProvider){
        super(2,4);
        this.dataSourceProvider = dataSourceProvider;
        this.viewConfigManager = new ViewConfigManager();
        setSizeFull();
        initGridContent();
        initGridSpacing();
    }

    private void initGridSpacing() {
        setColumnExpandRatio(1,4);
        setRowExpandRatio(2,2);
        setRowExpandRatio(3,1);
    }

    private void initGridContent() {
        ConfigPage configPage = new ConfigPage(viewConfigManager, dataSourceProvider);
        addComponent(configPage, 0,0,0,3);
        Label titleLabel = new Label("<h1>Configuration Page</h1>", ContentMode.HTML);
        titleLabel.setHeight("100px");
        addComponent(titleLabel, 1, 0);
        setComponentAlignment(titleLabel, Alignment.TOP_CENTER);
        DraggableComponentsView draggableComponentsView = new DraggableComponentsView();
        addComponent(draggableComponentsView, 1, 1);
        UserView userView = new UserView(viewConfigManager);
        addComponent(userView, 1,2);
    }
}
