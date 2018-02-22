package de.mjust.master.navigator;

import com.vaadin.annotations.Theme;
import com.vaadin.annotations.VaadinServletConfiguration;
import com.vaadin.navigator.Navigator;
import com.vaadin.navigator.View;
import com.vaadin.server.VaadinRequest;
import com.vaadin.server.VaadinServlet;
import com.vaadin.ui.*;
import de.mjust.master.configUI.SubPage;

import javax.servlet.annotation.WebServlet;

public class NavigatorUI extends UI {

    private final String STARTVIEW = "";
    private final String CONFIGVIEW = "config";

    Navigator navigator;

    @Override
    protected void init(VaadinRequest vaadinRequest) {
        navigator = new Navigator(this, this);
        navigator.addView(STARTVIEW, new StartPage());
        navigator.addView(CONFIGVIEW, new SubPage());
    }

    @Theme("mytheme")
    public class StartPage extends VerticalLayout implements View {

        public StartPage(){

            Button button = new Button("Configure View");
            button.addClickListener(e -> {
                navigator.navigateTo(CONFIGVIEW);
            });

            addComponents(button);

            setContent(this);
        }

}
    @WebServlet(urlPatterns = "/*", name = "MyUIServlet", asyncSupported = true)
    @VaadinServletConfiguration(ui = NavigatorUI.class, productionMode = false)
    public static class MyUIServlet extends VaadinServlet {
    }
}
