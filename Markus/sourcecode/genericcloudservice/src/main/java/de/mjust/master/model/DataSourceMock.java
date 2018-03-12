package de.mjust.master.model;

import de.mjust.master.provider.IDataProvider;

import java.util.Arrays;
import java.util.Collection;

public class DataSourceMock implements IDataSource {

    private String sourceName;

    private Collection<DataObject> dataObjects;

    private IDataProvider dataProvider;

    public DataSourceMock(String name){
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

    public Collection<DataObject> getDataObjects() {
        if(this.dataObjects == null){
            this.dataObjects = Arrays.asList(new DataObject("energyConsumption", 10), new DataObject("ph-value", 0.03), new DataObject("plantName", "plantB"));
        }
        return dataObjects;
    }
}
