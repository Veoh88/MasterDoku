package de.mjust.master.configUI;

import com.vaadin.data.provider.ListDataProvider;
import com.vaadin.shared.ui.dnd.DropEffect;
import com.vaadin.ui.*;
import com.vaadin.ui.dnd.DropTargetExtension;
import com.vaadin.ui.themes.ValoTheme;
import de.mjust.master.configUI.components.ComponentBuilder;
import de.mjust.master.configUI.components.ComponentType;
import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.model.DataObject;

import java.util.Optional;

public class UserView extends HorizontalLayout {

    private ViewConfigManager viewConfigManager;
    private ComponentBuilder componentBuilder;

    public UserView(ViewConfigManager viewConfigManager) {
        this.viewConfigManager = viewConfigManager;
        this.componentBuilder = new ComponentBuilder();
        this.viewConfigManager.registerObserver(componentBuilder);
        setSizeFull();
        VerticalLayout dropTargetLayout = new VerticalLayout();
        dropTargetLayout.setCaption("Drop things inside me");
        dropTargetLayout.addStyleName(ValoTheme.LAYOUT_CARD);

// make the layout accept drops
        DropTargetExtension<VerticalLayout> dropTarget = new DropTargetExtension<>(dropTargetLayout);

// the drop effect must match the allowed effect in the drag source for a successful drop
        dropTarget.setDropEffect(DropEffect.MOVE);
        addComponent(dropTargetLayout);

        dropTarget.addDropListener(event -> {
            // if the drag source is in the same UI as the target
            Optional<AbstractComponent> dragSource = event.getDragSourceComponent();
            if (dragSource.isPresent() && dragSource.get() instanceof Label) {
                // move the label to the layout
                dropTargetLayout.addComponent(dragSource.get());

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
            default:
                break;
        }

    }
}