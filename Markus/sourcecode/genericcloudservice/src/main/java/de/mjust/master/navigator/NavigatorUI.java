package de.mjust.master.navigator;

import com.vaadin.annotations.Theme;
import com.vaadin.annotations.VaadinServletConfiguration;
import com.vaadin.navigator.Navigator;
import com.vaadin.navigator.View;
import com.vaadin.server.VaadinRequest;
import com.vaadin.server.VaadinServlet;
import com.vaadin.ui.*;
import de.mjust.master.configUI.ConfigGrid;
import de.mjust.master.configUI.DataSourceConfigPage;
import de.mjust.master.provider.DataSourcesProvider;
import de.mjust.master.provider.IDataSourceProvider;

import javax.servlet.annotation.WebServlet;

public class NavigatorUI extends UI {

    private final String STARTVIEW = "";
    private final String CONFIGVIEW = "config";
    private final String DATASOURCECONFIG = "datasources";

    private IDataSourceProvider dataSourceProvider;

    Navigator navigator;

    @Override
    protected void init(VaadinRequest vaadinRequest) {
        this.dataSourceProvider = new DataSourcesProvider();
        navigator = new Navigator(this, this);
        navigator.addView(STARTVIEW, new StartPage());
        navigator.addView(CONFIGVIEW, new ConfigGrid(dataSourceProvider));
        navigator.addView(DATASOURCECONFIG, new DataSourceConfigPage(dataSourceProvider));
    }

    @Theme("mytheme")
    public class StartPage extends VerticalLayout implements View {

        public StartPage(){

            Button userViewButton = new Button("Configure UserViews");
            Button dataSourcesButton = new Button("Configure DataSources");
            userViewButton.addClickListener(e -> {
                navigator.navigateTo(CONFIGVIEW);
            });
            dataSourcesButton.addClickListener(e -> {
                navigator.navigateTo(DATASOURCECONFIG);
            });

            addComponents(userViewButton,dataSourcesButton);

            setContent(this);
        }

}
    @WebServlet(urlPatterns = "/*", name = "MyUIServlet", asyncSupported = true)
    @VaadinServletConfiguration(ui = NavigatorUI.class, productionMode = false)
    public static class MyUIServlet extends VaadinServlet {
    }
}
