package de.mjust.master.navigator;

import com.vaadin.annotations.PreserveOnRefresh;
import com.vaadin.annotations.Theme;
import com.vaadin.annotations.VaadinServletConfiguration;
import com.vaadin.navigator.Navigator;
import com.vaadin.navigator.View;
import com.vaadin.server.VaadinRequest;
import com.vaadin.server.VaadinServlet;
import com.vaadin.ui.*;
import de.mjust.master.configUI.ConfigGrid;
import de.mjust.master.configUI.DataSourceConfigPage;
import de.mjust.master.configUI.UserView;
import de.mjust.master.configUI.UserViewConfig;
import de.mjust.master.login.LoginPage;
import de.mjust.master.model.UserRegistry;
import de.mjust.master.provider.DataSourcesProvider;
import de.mjust.master.provider.IDataSourceProvider;
import de.mjust.master.provider.UserProvider;

import javax.servlet.annotation.WebServlet;

@PreserveOnRefresh
@Theme("mytheme")
public class NavigatorUI extends UI {

    private static final String STARTVIEW = "";
    private static final String CONFIGVIEW = "config";
    private static final String USERVIEW = "userview";
    private static final String DATASOURCECONFIG = "datasources";

    private IDataSourceProvider dataSourceProvider;
    private UserRegistry userRegistry;
    private UserProvider userProvider;

    public static UserProvider AUTH;

    Navigator navigator;

    @Override
    protected void init(VaadinRequest vaadinRequest) {
        AUTH = new UserProvider();
        this.dataSourceProvider = new DataSourcesProvider();
        this.userRegistry = new UserRegistry();
        this.userProvider = new UserProvider();
        navigator = new Navigator(this, this);
        navigator.addView(STARTVIEW, new LoginPage());
        navigator.addView(CONFIGVIEW, new ConfigGrid(dataSourceProvider, userRegistry, userProvider));
        navigator.addView(DATASOURCECONFIG, new DataSourceConfigPage(dataSourceProvider));
        navigator.addView(USERVIEW, new UserView(userRegistry, userProvider));
    }

    public static class StartPage extends VerticalLayout implements View {

        public StartPage(){

            Button userViewButton = new Button("Configure UserViews");
            Button dataSourcesButton = new Button("Configure DataSources");
            userViewButton.addClickListener(e -> {
                getUI().getNavigator().navigateTo(CONFIGVIEW);
            });
            dataSourcesButton.addClickListener(e -> {
                getUI().getNavigator().navigateTo(DATASOURCECONFIG);
            });

            addComponents(userViewButton,dataSourcesButton);
        }

}
    @WebServlet(urlPatterns = "/*", name = "MyUIServlet", asyncSupported = true)
    @VaadinServletConfiguration(ui = NavigatorUI.class, productionMode = false)
    public static class MyUIServlet extends VaadinServlet {
    }
}
