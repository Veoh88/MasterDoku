package de.mjust.master.scheduler;

import de.mjust.master.configUI.manager.ViewConfigManager;
import de.mjust.master.model.IDataSource;

import java.util.Set;
import java.util.TimerTask;

public class PollingScheduler extends TimerTask{

    private ViewConfigManager viewConfigManager;
    private Set<IDataSource> dataSourceSet;

    public PollingScheduler(){

    }

    public void scheduleSourceUpdates() {

    }

    @Override
    public void run() {

    }
}
