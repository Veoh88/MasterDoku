package de.mjust.master.model;

import de.mjust.master.model.dbmodel.User;

import java.util.ArrayList;
import java.util.Collection;
import java.util.UUID;

public class UserRegistry {

    private UserComponentMap userComponentMappings;

    public UserRegistry() {
        initUserMappings();
    }

    private void initUserMappings() {
        this.userComponentMappings = new UserComponentMap();
    }

    public void addUserMapping(User user, Collection<UserComponent> userComponents) {
        Collection<UserComponent> oldUserComponents = this.userComponentMappings.get(user);
        Collection<UUID> removableUUIDs = new ArrayList<>();
        if (oldUserComponents != null) {
            for (UserComponent userComponent : userComponents) {
                if (oldUserComponents.stream().anyMatch(x -> x.getUuid().equals(userComponent.getUuid()))) {
                    UserComponent editedUserComponent = oldUserComponents.stream().filter(x -> x.getUuid().equals(userComponent.getUuid())).findFirst().orElse(null);
                    editedUserComponent.setConfiguration(userComponent.getConfiguration());
                    editedUserComponent.setSelectedFields(userComponent.getSelectedFields());
                    removableUUIDs.add(editedUserComponent.getUuid());
                }
            }
        }
        userComponents.removeIf(x -> removableUUIDs.contains(x.getUuid()));
        this.userComponentMappings.put(user, userComponents);
    }

    public boolean userHasComponents(User user) {
        return this.userComponentMappings.containsKey(user);
    }

    public Collection<UserComponent> getUserMappings(User user) {
        return this.userComponentMappings.get(user);
    }
}
