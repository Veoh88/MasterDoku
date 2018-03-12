package de.mjust.master.model;

import de.mjust.master.provider.IDataProvider;

import java.util.Collection;

public interface IDataSource {

    String getSourceName();
    String getSourceOrigin();
    void setSourceOrigin(String sourceOrigin);
    void setDataProvider(IDataProvider provider);
    Collection<DataObject> getDataObjects();
}
