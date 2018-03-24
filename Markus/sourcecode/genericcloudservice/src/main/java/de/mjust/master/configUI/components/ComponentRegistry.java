package de.mjust.master.configUI.components;

import com.vaadin.ui.Component;
import de.mjust.master.model.DataObject;

import java.util.*;

public class ComponentRegistry {

    private Map<UUID, Component> registeredComponents;
    private Map<UUID, Set<DataObject>> registeredFields;

    public ComponentRegistry() {
        this.registeredComponents = new HashMap<>();
        this.registeredFields = new HashMap<>();
    }

    public UUID addComponent(Component component, Set<DataObject> selectedFields) {
        if (!this.registeredComponents.values().contains(component)) {
            UUID newUuid = UUID.randomUUID();
            this.registeredComponents.put(newUuid, component);
            this.registeredFields.put(newUuid, selectedFields);
            return newUuid;
        }
        return null;
    }

    public Component getComponentByUUID(UUID uuid) {
        return this.registeredComponents.get(uuid);
    }

    public Set<DataObject> getDataObjectsByUUID(UUID uuid) {
        return this.registeredFields.get(uuid);
    }

    public Collection<Component> getAllComponents() {
        return this.registeredComponents.values();
    }

    public Map<UUID, Component> getAllComponentsWithUUID() {
        return this.registeredComponents;
    }

    public Set<UUID> getUUIDs() {
        return this.registeredComponents.keySet();
    }

    public void removeComponents() {
        this.registeredFields.clear();
        this.registeredComponents.clear();
    }
}
