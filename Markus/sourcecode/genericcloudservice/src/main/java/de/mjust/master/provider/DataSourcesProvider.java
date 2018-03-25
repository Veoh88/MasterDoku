package de.mjust.master.provider;

import de.mjust.master.model.DataSourceMockA;
import de.mjust.master.model.DataSourceMockB;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.RestDataSource;

import java.util.ArrayList;
import java.util.Collection;

public class DataSourcesProvider implements IDataSourceProvider{

    private Collection<IDataSource> dataSources;

    public DataSourcesProvider(){
      this.dataSources = new ArrayList<>();
        dataSources.add(new RestDataSource("WPSteps1", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WPSteps2", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/2/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WPSteps3", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/3/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WPSteps4", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/4/treatmentStepTypes"));
        dataSources.add(new RestDataSource("WPQuality1", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        dataSources.add(new RestDataSource("WPQuality2", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/2/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        dataSources.add(new RestDataSource("NO2WP3", "http://default-environment.senykdj5qb.eu-west-2.elasticbeanstalk.com/provider/waterPlants/3/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        dataSources.add(new RestDataSource("NO2WP4", "http://default-environment.senykdj5qb.eu-west-2.elasticbeanstalk.com/provider/waterPlants/4/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        dataSources.add(new RestDataSource("TempWP3", "http://default-environment.senykdj5qb.eu-west-2.elasticbeanstalk.com/provider/waterPlants/3/treatmentsteptypes/1/qualityindicatortypes/1/data"));
        dataSources.add(new RestDataSource("TempWP4", "http://default-environment.senykdj5qb.eu-west-2.elasticbeanstalk.com/provider/waterPlants/4/treatmentsteptypes/1/qualityindicatortypes/1/data"));
        dataSources.add(new DataSourceMockA("TestSource1"));
        dataSources.add(new DataSourceMockB("TestSource2"));
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
