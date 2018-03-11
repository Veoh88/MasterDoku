package de.mjust.master.provider;

import de.mjust.master.model.IDataSource;

import java.util.Collection;

public interface IDataSourceProvider {
     Collection<IDataSource> getDataSources();

}
