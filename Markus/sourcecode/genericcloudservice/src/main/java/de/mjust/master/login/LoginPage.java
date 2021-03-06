package de.mjust.master.login;

import com.vaadin.navigator.View;
import com.vaadin.navigator.ViewChangeListener.ViewChangeEvent;
import com.vaadin.server.Page;
import com.vaadin.server.VaadinSession;
import com.vaadin.ui.Alignment;
import com.vaadin.ui.Button;
import com.vaadin.ui.Button.ClickEvent;
import com.vaadin.ui.Button.ClickListener;
import com.vaadin.ui.FormLayout;
import com.vaadin.ui.Notification;
import com.vaadin.ui.Panel;
import com.vaadin.ui.PasswordField;
import com.vaadin.ui.TextField;
import com.vaadin.ui.VerticalLayout;
import de.mjust.master.configUI.UserView;
import de.mjust.master.navigator.NavigatorUI;

public class LoginPage extends VerticalLayout implements View {
    private static final long serialVersionUID = 1L;
    public static final String NAME = "";

    public LoginPage(){
        Panel panel = new Panel("Login");
        panel.setSizeUndefined();
        addComponent(panel);


        FormLayout content = new FormLayout();
        TextField username = new TextField("Username");
        content.addComponent(username);
        PasswordField password = new PasswordField("Password");
        content.addComponent(password);

        Button send = new Button("Enter");
        send.addClickListener(new ClickListener() {
            private static final long serialVersionUID = 1L;

            @Override
            public void buttonClick(ClickEvent event) {
                if(NavigatorUI.AUTH.authenticateUser(username.getValue(), password.getValue())){
                    VaadinSession.getCurrent().setAttribute("user", username.getValue());
                    if(username.getValue().equals("admin")) {
                        getUI().getNavigator().addView("start", NavigatorUI.StartPage.class);
                        Page.getCurrent().setUriFragment("!" + "start");
                    }
                    else {
                        Page.getCurrent().setUriFragment("!" + "userview");
                    }
                }else{
                    Notification.show("Invalid credentials", Notification.Type.ERROR_MESSAGE);
                }
            }

        });
        content.addComponent(send);
        content.setSizeUndefined();
        content.setMargin(true);
        panel.setContent(content);
        setComponentAlignment(panel, Alignment.MIDDLE_CENTER);

    }

    @Override
    public void enter(ViewChangeEvent event) {

    }

}

