package de.mjust.master.provider;

import de.mjust.master.model.dbmodel.UserRole;

import java.util.ArrayList;
import java.util.Collection;

public class UserRoleProvider {

    Collection<UserRole> roles;

    public UserRoleProvider(){
        this.roles = new ArrayList<>();
        roles.add(new UserRole("WaterCompanyA"));
        roles.add(new UserRole("WaterCompanyB"));
    }

    public Collection<UserRole> getRoles(){
        return this.roles;
    }
}
