package de.mjust.master.model.dbmodel;


import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.ManyToMany;
import java.util.HashSet;
import java.util.Set;

@Entity
public class User extends UserRole {

    @Id
    @GeneratedValue
    private long Id;
    private String name;
    private String password;

    public User(){
        this.name = "admin";
        this.password = "admin";
    }

    public User(String name, String password){
        this.name = name;
        this.password = password;
    }

    @ManyToMany
    private Set<UserRole> userRoles = new HashSet<UserRole>();

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Set<UserRole> getUserRoles() {
        return userRoles;
    }

    public boolean addUserRole(UserRole userRole) {
        return this.userRoles.add(userRole);
    }

    public Boolean authenticate(String username, String password){
        if(username.equals(getName()) && password.equals(getPassword())){
            return true;
        }
        return false;
    }
}
