package de.mjust.master.model;

import com.vaadin.addon.charts.model.ChartType;
import com.vaadin.addon.charts.model.Configuration;

import java.util.Collection;
import java.util.Set;
import java.util.UUID;


public class UserComponent {

    private boolean isChart = false;
    private boolean isTable = false;
    private Configuration configuration;
    private ChartType chartType;
    private Set<DataObject> selectedFields;
    private UUID uuid;

    public boolean isChart() {
        return isChart;
    }

    public void setChart(boolean chart) {
        isChart = chart;
    }

    public boolean isTable() {
        return isTable;
    }

    public void setTable(boolean table) {
        isTable = table;
    }

    public Configuration getConfiguration() {
        return configuration;
    }

    public void setConfiguration(Configuration configuration) {
        this.configuration = configuration;
    }

    public ChartType getChartType() {
        return chartType;
    }

    public void setChartType(ChartType chartType) {
        this.chartType = chartType;
    }

    public Set<DataObject> getSelectedFields() {
        return selectedFields;
    }

    public void setSelectedFields(Set<DataObject> selectedFields) {
        this.selectedFields = selectedFields;
    }

    public UUID getUuid() {
        return uuid;
    }

    public void setUuid(UUID uuid) {
        this.uuid = uuid;
    }
}
