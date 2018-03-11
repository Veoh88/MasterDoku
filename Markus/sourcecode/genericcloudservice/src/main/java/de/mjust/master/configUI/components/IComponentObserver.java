package de.mjust.master.configUI.components;

import de.mjust.master.model.DataObject;

import java.util.Set;

public interface IComponentObserver {

    void update(Set<DataObject> selectedFields);
}
