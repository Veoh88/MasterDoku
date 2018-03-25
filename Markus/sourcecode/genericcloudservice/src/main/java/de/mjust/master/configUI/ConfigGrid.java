package de.mjust.master.configUI;

import com.vaadin.navigator.View;
import com.vaadin.navigator.ViewChangeListener;
import com.vaadin.shared.ui.ContentMode;
import com.vaadin.ui.Alignment;
import com.vaadin.ui.GridLayout;
import com.vaadin.ui.Label;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.configUI.manager.ViewRegistry;
import de.mjust.master.model.UserRegistry;
import de.mjust.master.provider.IDataSourceProvider;
import de.mjust.master.provider.UserProvider;
import de.mjust.master.provider.UserRoleProvider;

public class ConfigGrid extends GridLayout implements View{

    private ViewConfigManager viewConfigManager;
    private IDataSourceProvider dataSourceProvider;
    private ComponentBuilder componentBuilder;
    private ConfigPage configPage;
    private UserProvider userProvider;
    private UserRoleProvider userRoleProvider;
    private UserRegistry userRegistry;
    private ViewRegistry viewRegistry;


    public ConfigGrid(IDataSourceProvider dataSourceProvider){
        super(2,4);
        this.viewRegistry = ViewRegistry.getInstance();
        this.dataSourceProvider = dataSourceProvider;
        this.viewConfigManager = new ViewConfigManager();
        this.componentBuilder = new ComponentBuilder();
        this.userProvider = new UserProvider();
        this.userRoleProvider = new UserRoleProvider();
        this.userRegistry = new UserRegistry();
        setSizeFull();
        setResponsive(true);
        setStyleName("layout-with-border");
        initGridContent();
        initGridSpacing();
    }

    private void initGridSpacing() {
        setColumnExpandRatio(1,4);
        setRowExpandRatio(2,2);
        setRowExpandRatio(3,1);
    }

    private void initGridContent() {
        configPage = new ConfigPage(viewConfigManager, dataSourceProvider, userProvider, userRoleProvider, userRegistry, componentBuilder);
        this.viewRegistry.setConfigPage(configPage);
        addComponent(configPage, 0,0,0,3);
        Label titleLabel = new Label("<h1>Configuration Page</h1>", ContentMode.HTML);
        titleLabel.setHeight("100px");
        addComponent(titleLabel, 1, 0);
        setComponentAlignment(titleLabel, Alignment.TOP_CENTER);
        DraggableComponentsView draggableComponentsView = new DraggableComponentsView();
        addComponent(draggableComponentsView, 1, 1);
        UserView userView = new UserView(viewConfigManager, componentBuilder);
        this.viewRegistry.setUserView(userView);
        addComponent(userView, 1,2);
        ComponentConfig componentConfig = new ComponentConfig(viewConfigManager, componentBuilder);
        this.viewRegistry.setComponentConfig(componentConfig);
        addComponent(componentConfig, 1, 3);
    }

    @Override
    public void enter(ViewChangeListener.ViewChangeEvent event){
        this.configPage.enterView();
    }
}
