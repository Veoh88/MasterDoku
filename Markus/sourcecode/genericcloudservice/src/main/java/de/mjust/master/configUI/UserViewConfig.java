package de.mjust.master.configUI;

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
import de.mjust.master.model.dbmodel.User;

import java.util.Collection;
import java.util.Optional;

public class UserViewConfig extends GridLayout {

    private ViewConfigManager viewConfigManager;
    private ComponentBuilder componentBuilder;

    public UserViewConfig(ViewConfigManager viewConfigManager, ComponentBuilder componentBuilder) {
        super(3,2);
        this.viewConfigManager = viewConfigManager;
        this.componentBuilder = componentBuilder;
        this.viewConfigManager.registerObserver(this.componentBuilder);
        initDropTarget();
        setStyleName("backColorGrey");
        setSizeFull();
    }

    private void initDropTarget() {
        removeAllComponents();
        VerticalLayout dropTargetLayout = new VerticalLayout();
        Label dropLabel = new Label("<h2>Drop new component here</h2>", ContentMode.HTML);
        dropTargetLayout.addComponent(dropLabel);
        dropTargetLayout.setComponentAlignment(dropLabel, Alignment.MIDDLE_CENTER);
        dropTargetLayout.addStyleName(ValoTheme.LAYOUT_CARD);
        dropTargetLayout.setWidth("500px");
        dropTargetLayout.setHeight("400px");

// make the layout accept drops
        DropTargetExtension<VerticalLayout> dropTarget = new DropTargetExtension<>(dropTargetLayout);

// the drop effect must match the allowed effect in the drag source for a successful drop
        dropTarget.setDropEffect(DropEffect.COPY);
        addComponent(dropTargetLayout, 0,0);

        dropTarget.addDropListener(event -> {
            // if the drag source is in the same UI as the target
            Optional<AbstractComponent> dragSource = event.getDragSourceComponent();
            if (dragSource.isPresent() && dragSource.get() instanceof Label) {

                // get possible transfer data
                Optional<String> optionalMessage = event.getDataTransferData("text/html");
                if (optionalMessage != null) {
                    Notification.show("DropEvent with data transfer html: " + optionalMessage);
                } else {
                    // get transfer text
                    String message = event.getDataTransferText();
                    Notification.show("DropEvent with data transfer text: " + message);
                }

                // handle possible server side drag data, if the drag source was in the same UI
                event.getDragData().ifPresent(data -> createViewComponent((ComponentType) data));
            }
        });
    }

    private void createViewComponent(ComponentType data) {
        switch (data) {
            case TABLE:
                addComponent(componentBuilder.buildTable(this.viewConfigManager.getSelectedFields()));
                break;
            case BARCHART:
                addComponent(componentBuilder.buildBarChart(this.viewConfigManager.getSelectedFields()));
                break;
            case PIECHART:
                addComponent(componentBuilder.buildPieChart(this.viewConfigManager.getSelectedFields()));
                break;
            case LINECHART:
                addComponent(componentBuilder.buildLineChart(this.viewConfigManager.getSelectedFields()));
                break;
            default:
                break;
        }

    }

    public void initUserComponents(Collection<UserComponent> userComponents) {
        initDropTarget();
        Collection<Component> components = this.componentBuilder.buildUserComponents(userComponents);
        for (Component viewComponent : components) {
            addComponents(viewComponent);
        }
    }

    public void setBlankView(User value) {
        initDropTarget();
    }
}