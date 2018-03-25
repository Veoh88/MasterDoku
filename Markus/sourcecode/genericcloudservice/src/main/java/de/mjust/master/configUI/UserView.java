package de.mjust.master.configUI;

import com.vaadin.navigator.View;
import com.vaadin.navigator.ViewChangeListener;
import com.vaadin.server.Page;
import com.vaadin.server.VaadinSession;
import com.vaadin.shared.ui.ContentMode;
import com.vaadin.shared.ui.dnd.DropEffect;
import com.vaadin.ui.*;
import com.vaadin.ui.dnd.DropTargetExtension;
import com.vaadin.ui.themes.ValoTheme;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.components.ComponentType;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.model.UserComponent;
import de.mjust.master.model.UserComponentMap;
import de.mjust.master.model.UserRegistry;
import de.mjust.master.model.dbmodel.User;
import de.mjust.master.provider.UserProvider;

import java.util.Collection;
import java.util.Optional;

public class UserView extends GridLayout implements View {

    private ComponentBuilder componentBuilder;
    private UserRegistry userRegistry;
    private UserProvider userProvider;
    private Label helloLabel;

    public UserView(UserRegistry userRegistry, UserProvider userProvider) {
        super(4,3);
        this.userRegistry = userRegistry;
        this.userProvider = userProvider;
        this.componentBuilder = new ComponentBuilder();
        setSizeFull();
        setHeight("1024px");
        setWidth("100%");
        setRowExpandRatio(0,1);
        setRowExpandRatio(1,3);
        setRowExpandRatio(2,3);
        initUserComponents();

    }

    public void initUserComponents() {
        Collection<UserComponent> userComponents = this.userRegistry.getUserMappings(this.userProvider.getUserByName((String) VaadinSession.getCurrent().getAttribute("user")));
        if(userComponents != null) {
            Collection<Component> components = this.componentBuilder.buildUserComponents(userComponents);
            for (Component viewComponent : components) {
                addComponents(viewComponent);
                setComponentAlignment(viewComponent, Alignment.TOP_LEFT);
            }
        }
        else
        {
            addComponent(new Label("nothing to show here"));
        }
    }

    @Override
    public void enter(ViewChangeListener.ViewChangeEvent event){
        removeAllComponents();
        VerticalLayout welcomeLayout = new VerticalLayout();
        Button logout = new Button("<< Logout");
        logout.addClickListener(x -> Page.getCurrent().setUriFragment(""));
        helloLabel = new Label("<h1>Hello, " + VaadinSession.getCurrent().getAttribute("user")+ "</h1>", ContentMode.HTML);
        welcomeLayout.addComponents(logout, helloLabel);
        addComponent(welcomeLayout,0,0,3,0);
        initUserComponents();
    }
}
