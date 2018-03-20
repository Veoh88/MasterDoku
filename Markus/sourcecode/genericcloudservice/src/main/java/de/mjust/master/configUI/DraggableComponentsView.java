package de.mjust.master.configUI;

import com.vaadin.icons.VaadinIcons;
import com.vaadin.server.FontIcon;
import com.vaadin.server.GenericFontIcon;
import com.vaadin.shared.ui.dnd.EffectAllowed;
import com.vaadin.ui.HorizontalLayout;
import com.vaadin.ui.IconGenerator;
import com.vaadin.ui.Label;
import com.vaadin.ui.dnd.DragSourceExtension;
import com.vaadin.icons.*;
import de.mjust.master.configUI.components.ComponentType;


public class DraggableComponentsView extends HorizontalLayout {

    public DraggableComponentsView(){

        createTableDrag();
        createBarChartDrag();
        createPieChartDrag();
    }

    private void createBarChartDrag() {

        Label draggableLabel = new Label();
        draggableLabel.setIcon(VaadinIcons.BAR_CHART);
        draggableLabel.setValue("Barchart");
        draggableLabel.setWidth("64px");
        draggableLabel.setHeight("64px");
        DragSourceExtension<Label> dragSource = new DragSourceExtension<>(draggableLabel);
// set the allowed effect
        dragSource.setEffectAllowed(EffectAllowed.COPY_MOVE);
// set the text to transfer
        dragSource.setDataTransferText("hello receiver");
// set other data to transfer (in this case HTML)
        dragSource.setDataTransferData("text/html", "<label>hello receiver</label>");
        dragSource.setDragData(ComponentType.BARCHART);
        addComponent(draggableLabel);
    }

    private void createPieChartDrag() {
        Label draggableLabel = new Label();
        draggableLabel.setIcon(VaadinIcons.PIE_CHART);
        draggableLabel.setValue("Piechart");
        draggableLabel.setWidth("64px");
        draggableLabel.setHeight("64px");
        DragSourceExtension<Label> dragSource = new DragSourceExtension<>(draggableLabel);
// set the allowed effect
        dragSource.setEffectAllowed(EffectAllowed.COPY_MOVE);
// set the text to transfer
        dragSource.setDataTransferText("hello receiver");
// set other data to transfer (in this case HTML)
        dragSource.setDataTransferData("text/html", "<label>hello receiver</label>");
        dragSource.setDragData(ComponentType.PIECHART);
        addComponent(draggableLabel);
    }

    private void createTableDrag() {
        Label draggableLabel = new Label();
        draggableLabel.setIcon(VaadinIcons.TABLE);
        draggableLabel.setValue("Table");
        draggableLabel.setWidth("64px");
        draggableLabel.setHeight("64px");
        DragSourceExtension<Label> dragSource = new DragSourceExtension<>(draggableLabel);
// set the allowed effect
        dragSource.setEffectAllowed(EffectAllowed.COPY_MOVE);
// set the text to transfer
        dragSource.setDataTransferText("hello receiver");
// set other data to transfer (in this case HTML)
        dragSource.setDataTransferData("text/html", "<label>hello receiver</label>");
        dragSource.setDragData(ComponentType.TABLE);
        addComponent(draggableLabel);
    }
}
