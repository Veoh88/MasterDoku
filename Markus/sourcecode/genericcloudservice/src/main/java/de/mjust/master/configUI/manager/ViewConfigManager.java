package de.mjust.master.configUI.manager;

import de.mjust.master.configUI.components.IComponentObserver;
import de.mjust.master.model.DataObject;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

public class ViewConfigManager {

    public ViewConfigManager() {
        this.selectedFields = new HashSet<>();
        this.componentObserverList = new ArrayList<>();
    }

    private Set<DataObject> selectedFields;

    private Collection<IComponentObserver> componentObserverList;

    public Set<DataObject> getSelectedFields() {
        return selectedFields;
    }

    public void setSelectedFields(Set<DataObject> selectedFields) {
        this.selectedFields = selectedFields;
    }

    public boolean addSelectedField(DataObject object) {
        if (this.selectedFields.add(object)) {
            notifySelectionChange();
            return true;
        }
        return false;
    }

    public boolean removeSelectedField(DataObject dataObjects) {
        if (this.selectedFields.remove(dataObjects)) {
            notifySelectionChange();
            return true;
        }
        return false;
    }

    public boolean removeAllFromSelectedFields(Collection<DataObject> dataObjects) {
        if (this.selectedFields.removeAll(dataObjects)) {
            notifySelectionChange();
            return true;
        }
        return false;
    }

    public void registerObserver(IComponentObserver observer){
        this.componentObserverList.add(observer);
    }

    private void notifySelectionChange() {
        componentObserverList.stream().forEach(x -> x.update(this.selectedFields));
    }
}
