package de.mjust.master.model;

public class DataObject {

    public DataObject() {
    }

    public DataObject(String description, int value) {
        this.setDescription(description);
        this.setValue(value);
    }

    public DataObject(String description, long value) {
        this.setDescription(description);
        this.setValue(value);
    }

    public DataObject(String description, double value) {
        this.setDescription(description);
        this.setValue(value);
    }

    public DataObject(String description, String value) {
        this.setDescription(description);
        this.setValue(value);
    }

    private final int IDENTITYHASHCODE = System.identityHashCode(this);
    private String description;
    private Object value;
    private boolean isSelected = false;

    public void toggleSelection() {
        this.isSelected = !this.isSelected;
    }

    public String getDescription() {
        return description;
    }

    public String getDescriptionWithType() {
        return description + " (" + value.getClass().getSimpleName() + ")";
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public Object getValue() {
        return value;
    }

    public void setValue(Object value) {
        this.value = value;
    }
}
