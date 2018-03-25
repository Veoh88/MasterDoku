package de.mjust.master.provider;

import de.mjust.master.model.dbmodel.User;
import de.mjust.master.model.dbmodel.UserRole;

import java.util.ArrayList;
import java.util.Collection;

public class UserProvider {
    Collection<User> users;

    public UserProvider(){
        this.users = new ArrayList<>();
        this.users.add(new User("admin", "admin"));
        this.users.add(new User("EngineerA", "1234"));
        this.users.add(new User("EngineerB", "1234"));
    }

    public Collection<User> getUsers(){
        return this.users;
    }

    public boolean authenticateUser(String name, String password){
        User loginUser = this.users.stream().filter(x -> x.getName().equals(name)).findFirst().orElse(null);
        if(loginUser != null){
            loginUser.getPassword().equals(password);
            return true;
        }
        return false;
    }

    public User getUserByName(String name){
        return this.users.stream().filter(x -> x.getName().equals(name)).findFirst().orElse(null);
    }
}
