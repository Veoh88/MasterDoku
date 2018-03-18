package de.mjust.master.provider;

import de.mjust.master.model.dbmodel.User;

import java.util.ArrayList;
import java.util.Collection;

public class UserProvider {
    Collection<User> users;

    public UserProvider(){
        this.users = new ArrayList<>();
        this.users.add(new User("EngineerA", "1234"));
        this.users.add(new User("EngineerB", "1234"));
    }

    public Collection<User> getUsers(){
        return this.users;
    }
}
