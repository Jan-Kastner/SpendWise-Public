# TODO.md

## Tasks and Notes

### Additional Tasks

# TODO List

- [ ] **Add Logic for Removing Transactions**

  - **Description**: Implement logic in the repository to ensure that all transactions without any references to `TransactionGroupUser` are removed from the database. This logic should be part of the application and perform regular database maintenance to ensure that only valid transactions with corresponding links remain.

- [ ] **Implement DTOs for Property Update Restrictions**

  - **Description**: Implement logic within DTOs to ensure that certain properties of entities are not updatable. This involves defining which properties are allowed to be updated in the DTOs and ensuring that changes to these properties are not made. This logic should be applied to all relevant entities, including but not limited to `GroupUserEntity`. Implement the corresponding DTOs and validation logic to precisely control which properties can be modified.

- [ ] **Add Logic for Removing Groups After Last Member Removal**

  - **Description**: Implement logic in the application code to ensure that a group is removed if its last member (`GroupUser`) is deleted. This logic should be part of the user removal process from a group and should check if the group is empty, and if so, remove it from the database.

- [ ] **Ensure Each Group Has At Least One Member**

  - **Description**: Implement logic to ensure that a group cannot be created or saved unless it contains at least one `GroupUser`. This logic should be part of the application code and can be implemented in the business logic layer or validation logic to enforce that a group must always have at least one member before it can be persisted to the database.

### Unit of Work Group Tests

- [x] **CreateGroup_WithValidData_ShouldSucceed**  
       Verifies that a group with all required fields and valid data is successfully created.

- [x] **GetGroupById_ReturnsCorrectGroup**  
       Verifies that the group is correctly retrieved by ID and matches the expected data.

- [x] **UpdateGroup_UpdatesGroupInDatabase**  
       Verifies that the group is correctly updated in the database according to the provided changes.

- [x] **DeleteGroup_RemovesGroupFromDatabase**  
       Verifies that the group is correctly deleted from the database and is no longer accessible.

- [x] **UpdateGroup_NonExistentGroup_ShouldFail**  
       Verifies that updating a non-existent group fails and returns the correct error.

- [x] **DeleteGroup_NonExistentGroup_ShouldFail**  
       Verifies that attempting to delete a non-existent group fails and returns the correct error.

- [x] **CreateGroup_WithValidIcon_ShouldSucceed**  
       Verifies that a group with a valid icon is created correctly.

- [x] **UpdateGroup_IconChange_ShouldUpdateIcon**  
       Verifies that changing the group's icon is done correctly.

- [ ] **GetAllGroups_ShouldReturnAllGroups**  
       Verifies that the method for retrieving all groups returns the correct count and includes all existing groups.

- [ ] **GetGroupByName_ReturnsCorrectGroup**  
       Verifies that the group is correctly retrieved by name.

- [ ] **UpdateGroup_ChangeNameAndDescription_ShouldUpdateBoth**  
       Verifies that updating both the name and description of an existing group is done correctly.

- [ ] **UpdateGroup_WithEmptyDescription_ShouldBeAllowed**  
       Verifies that updating a group with an empty description (if allowed) is done correctly.

- [ ] **CreateGroup_WithSpecialCharactersInName_ShouldSucceed**  
       Verifies that creating a group with special characters in the name is handled correctly.

- [ ] **UpdateGroup_WithRemovedUsers_ShouldUpdateAssociations**  
       Verifies that when users are removed from a group, the group-user associations are updated accordingly (e.g., removed from the group).

- [ ] **DeleteGroup_WithActiveInvitations_ShouldHandleProperly**  
       Verifies that deleting a group with active invitations handles the invitations correctly (deletes them).

- [ ] **GetGroup_WithLimitAndUserDetails_ShouldReturnAllDetails**  
       Verifies that retrieving a group includes details of limits and users associated with the group.

- [ ] **CreateGroup_WithMultipleUsers_ShouldAssociateCorrectly**  
       Verifies that a group created with multiple users (or adding users to an existing group) correctly associates users with the group.
