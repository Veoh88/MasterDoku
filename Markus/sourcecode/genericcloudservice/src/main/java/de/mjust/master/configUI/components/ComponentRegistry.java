package de.mjust.master.configUI.components;

import com.vaadin.ui.Component;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public class ComponentRegistry {

    private Map<UUID, Component> registeredComponents;

    public ComponentRegistry() {
        this.registeredComponents = new HashMap<>();
    }

    public UUID addComponent(Component component){
        if(!this.registeredComponents.values().contains(component)){
            UUID newUuid = UUID.randomUUID();
            this.registeredComponents.put(newUuid, component);
            return newUuid;
        }
        return null;
    }

    public Component getComponentByUUID(UUID uuid){
        return this.registeredComponents.get(uuid);
    }

}
