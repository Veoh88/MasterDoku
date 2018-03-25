package de.mjust.master.model;

import de.mjust.master.provider.IDataProvider;

import java.util.Arrays;
import java.util.Collection;

public class DataSourceMockB implements IDataSource {

    private String sourceName;

    private int updateInterval = 0;

    private Collection<DataObject> dataObjects;

    private IDataProvider dataProvider;

    public DataSourceMockB(String name){
        this.sourceName = name;
    }

    public String getSourceName() {
        return sourceName;
    }

    @Override
    public String getSourceOrigin() {
        return "Mock";
    }

    @Override
    public void setSourceOrigin(String sourceOrigin) {

    }

    public void setDataProvider(IDataProvider dataProvider) {
        this.dataProvider = dataProvider;
    }

    @Override
    public void setUpdateInterval(int seconds) {
        this.updateInterval = seconds;
    }

    public Collection<DataObject> getDataObjects() {
        if(this.dataObjects == null){
            this.dataObjects = Arrays.asList(new DataObject("energyConsumption4", 25), new DataObject("ph-value", 0.03), new DataObject("plantName", "plantB"), new DataObject("energyConsumption5", 30), new DataObject("energyConsumption6", 40));
        }
        addThisSourceToDataObjects();
        return dataObjects;
    }

    private void addThisSourceToDataObjects() {
        for(DataObject dataObject: dataObjects){
            dataObject.setDataSourceOrigin(this);
        }
    }
}
