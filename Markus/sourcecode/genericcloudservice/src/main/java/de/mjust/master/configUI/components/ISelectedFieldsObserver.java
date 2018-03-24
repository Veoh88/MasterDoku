package de.mjust.master.configUI.components;

import de.mjust.master.model.DataObject;

import java.util.Set;

public interface ISelectedFieldsObserver {

    void update(Set<DataObject> selectedFields);

}
