package de.mjust.master.configUI.manager;

import de.mjust.master.configUI.*;
import de.mjust.master.login.LoginPage;

public class ViewRegistry {

    private static ViewRegistry instance;

    private ConfigGrid configGrid;
    private ConfigPage configPage;
    private ComponentConfig componentConfig;
    private DataSourceConfigPage dataSourceConfigPage;
    private LoginPage loginPage;
    private UserView userView;

    private ViewRegistry () {}

    public static synchronized ViewRegistry getInstance () {
        if (ViewRegistry.instance == null) {
            ViewRegistry.instance = new ViewRegistry ();
        }
        return ViewRegistry.instance;
    }

    public ConfigGrid getConfigGrid() {
        return configGrid;
    }

    public void setConfigGrid(ConfigGrid configGrid) {
        this.configGrid = configGrid;
    }

    public ConfigPage getConfigPage() {
        return configPage;
    }

    public void setConfigPage(ConfigPage configPage) {
        this.configPage = configPage;
    }

    public ComponentConfig getComponentConfig() {
        return componentConfig;
    }

    public void setComponentConfig(ComponentConfig componentConfig) {
        this.componentConfig = componentConfig;
    }

    public DataSourceConfigPage getDataSourceConfigPage() {
        return dataSourceConfigPage;
    }

    public void setDataSourceConfigPage(DataSourceConfigPage dataSourceConfigPage) {
        this.dataSourceConfigPage = dataSourceConfigPage;
    }

    public LoginPage getLoginPage() {
        return loginPage;
    }

    public void setLoginPage(LoginPage loginPage) {
        this.loginPage = loginPage;
    }

    public UserView getUserView() {
        return userView;
    }

    public void setUserView(UserView userView) {
        this.userView = userView;
    }
}
