package de.mjust.master.provider;

import de.mjust.master.model.IDataSource;

import java.util.Collection;

public interface IDataSourceProvider {
     Collection<IDataSource> getDataSources();
     void addDataSource(IDataSource dataSource);
     void setDataSources(Collection<IDataSource> dataSources);

}
