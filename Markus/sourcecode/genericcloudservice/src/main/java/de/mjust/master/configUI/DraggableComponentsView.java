package de.mjust.master.configUI;

import com.vaadin.shared.ui.dnd.EffectAllowed;
import com.vaadin.ui.HorizontalLayout;
import com.vaadin.ui.Label;
import com.vaadin.ui.dnd.DragSourceExtension;
import de.mjust.master.configUI.components.ComponentType;


public class DraggableComponentsView extends HorizontalLayout {

    public DraggableComponentsView(){

        createTableDrag();
        createBarChartDrag();

    }

    private void createBarChartDrag() {
        Label draggableLabel = new Label("I am a bar chart");
        DragSourceExtension<Label> dragSource = new DragSourceExtension<>(draggableLabel);
// set the allowed effect
        dragSource.setEffectAllowed(EffectAllowed.COPY);
// set the text to transfer
        dragSource.setDataTransferText("hello receiver");
// set other data to transfer (in this case HTML)
        dragSource.setDataTransferData("text/html", "<label>hello receiver</label>");
        dragSource.setDragData(ComponentType.BARCHART);
        addComponent(draggableLabel);
    }

    private void createTableDrag() {
        Label draggableLabel = new Label("I am a table");
        DragSourceExtension<Label> dragSource = new DragSourceExtension<>(draggableLabel);
// set the allowed effect
        dragSource.setEffectAllowed(EffectAllowed.COPY);
// set the text to transfer
        dragSource.setDataTransferText("hello receiver");
// set other data to transfer (in this case HTML)
        dragSource.setDataTransferData("text/html", "<label>hello receiver</label>");
        dragSource.setDragData(ComponentType.TABLE);
        addComponent(draggableLabel);
    }
}
