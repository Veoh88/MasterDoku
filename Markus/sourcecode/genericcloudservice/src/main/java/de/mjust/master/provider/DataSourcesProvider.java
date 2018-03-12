package de.mjust.master.provider;

import de.mjust.master.model.DataSourceMock;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.RestDataSource;
import de.mjust.master.model.dbmodel.DataSource;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class DataSourcesProvider implements IDataSourceProvider{

    private Collection<IDataSource> dataSources;

    public DataSourcesProvider(){
      this.dataSources = new ArrayList<>();
        dataSources.add(new RestDataSource("WaterPlant 1", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WaterPlant 2", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/2/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WaterPlant 3", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/3/treatmentStepTypes"));
        dataSources.add(new RestDataSource("RestSource", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        dataSources.add(new DataSourceMock("MockPlant"));
    }

    @Override
    public Collection<IDataSource> getDataSources() {
        return dataSources;
    }

    @Override
    public void addDataSource(IDataSource dataSource) {
        this.dataSources.add(dataSource);
    }

    @Override
    public void setDataSources(Collection<IDataSource> dataSources) {
        this.dataSources = dataSources;
    }
}
