package de.mjust.master.model;

import java.util.ArrayList;

public class DataObject {

    public DataObject() {
    }

    public DataObject(String description, int value) {
        this.setKey(description);
        this.setValue(value);
    }

    public DataObject(String description, long value) {
        this.setKey(description);
        this.setValue(value);
    }

    public DataObject(String description, double value) {
        this.setKey(description);
        this.setValue(value);
    }

    public DataObject(String description, String value) {
        this.setKey(description);
        this.setValue(value);
    }

    public DataObject(String description, Object value) {
        this.setKey(description);
        this.setValue(value);
    }

    private String key;
    private Object value;
    private IDataSource dataSourceOrigin;


    public String getKey() {
        return key;
    }

    public String getKeyWithType() {
        if (value instanceof ArrayList) {
            if ((((ArrayList) value).get(0) instanceof Integer)) {
                return key + " (Integer[])";
            }
            if ((((ArrayList) value).get(0) instanceof String)) {
                return key + " (String[])";
            }
            if ((((ArrayList) value).get(0) instanceof Long)) {
                return key + " (Long[])";
            }
            if ((((ArrayList) value).get(0) instanceof Double)) {
                return key + " (Double[])";
            } else {
                return key + " (null)";
            }
        } else {
            return key + " (" + value.getClass().getSimpleName() + ")";
        }
    }

    public void setKey(String description) {
        this.key = description;
    }

    public Object getValue() {
        return value;
    }

    public void setValue(Object value) {
        this.value = value;
    }

    public IDataSource getDataSourceOrigin() {
        return dataSourceOrigin;
    }

    public void setDataSourceOrigin(IDataSource dataSourceOrigin) {
        this.dataSourceOrigin = dataSourceOrigin;
    }
}
