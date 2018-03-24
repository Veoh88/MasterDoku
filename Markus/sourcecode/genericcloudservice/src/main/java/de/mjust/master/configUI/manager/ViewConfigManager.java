package de.mjust.master.configUI.manager;

import de.mjust.master.configUI.components.ISelectedFieldsObserver;
import de.mjust.master.model.DataObject;
import de.mjust.master.model.IDataSource;

import java.util.*;

public class ViewConfigManager {

    public ViewConfigManager() {
        this.selectedFields = new HashSet<>();
        this.selectedDataSources = new HashSet<>();
        this.componentObserverList = new ArrayList<>();
    }

    private Set<DataObject> selectedFields;
    private Set<IDataSource> selectedDataSources;

    private Collection<ISelectedFieldsObserver> componentObserverList;

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

    public boolean addSelectedDataSource(IDataSource dataSource){
        return this.selectedDataSources.add(dataSource);
    }

    public boolean removeSelectedDataSource(IDataSource dataSource){
        return this.selectedDataSources.remove(dataSource);
    }

    public void registerObserver(ISelectedFieldsObserver observer){
        this.componentObserverList.add(observer);
    }

    private void notifySelectionChange() {
        componentObserverList.stream().forEach(x -> x.update(this.selectedFields));
    }
}
