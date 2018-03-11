package de.mjust.master.provider;

import de.mjust.master.model.DataSourceMock;
import de.mjust.master.model.IDataSource;
import de.mjust.master.model.RestDataSource;
import de.mjust.master.model.dbmodel.DataSource;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class MockDataSourcesProvider implements IDataSourceProvider{

    @Override
    public Collection<IDataSource> getDataSources() {
        List<IDataSource> sampleDataSources = new ArrayList<>();
        sampleDataSources.add(new RestDataSource("WaterPlant 1", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentStepTypes"));
        sampleDataSources.add(new RestDataSource("WaterPlant 2", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/2/treatmentStepTypes"));
        sampleDataSources.add(new RestDataSource("WaterPlant 3", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/3/treatmentStepTypes"));
        sampleDataSources.add(new RestDataSource("RestSource", "http://harmonizationwebservice-dev.eu-west-2.elasticbeanstalk.com/provider/waterPlants/1/treatmentsteptypes/1/qualityindicatortypes/10/data"));
        sampleDataSources.add(new DataSourceMock("MockPlant"));
        return sampleDataSources;
    }
}
