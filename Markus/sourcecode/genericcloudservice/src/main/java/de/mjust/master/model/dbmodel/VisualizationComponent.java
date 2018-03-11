package de.mjust.master.model.dbmodel;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;

@Entity
public class VisualizationComponent {

    @GeneratedValue
    @Id
    private long id;

    private String vComponentType;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getvComponentType() {
        return vComponentType;
    }

    public void setvComponentType(String vComponentType) {
        this.vComponentType = vComponentType;
    }
}
