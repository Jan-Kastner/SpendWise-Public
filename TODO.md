# TODO.md

## Tasks and Notes

### Additional Tasks

- [ ] **Add Logic for Removing Transactions**
  - **Description**: Implement logic in the repository to ensure that all transactions without any references to `TransactionGroupUser` are removed from the database. This logic should be part of the application and perform regular database maintenance to ensure that only valid transactions with corresponding links remain.

- [ ] **Implement DTOs for Property Update Restrictions**
  - **Description**: Implement logic within DTOs to ensure that certain properties of entities are not updatable. This involves defining which properties are allowed to be updated in the DTOs and ensuring that changes to these properties are not made. This logic should be applied to all relevant entities, including but not limited to `GroupUserEntity`. Implement the corresponding DTOs and validation logic to precisely control which properties can be modified.

- [ ] **Add Logic for Removing Groups After Last Member Removal**
  - **Description**: Implement logic in the application code to ensure that a group is removed if its last member (`GroupUser`) is deleted. This logic should be part of the user removal process from a group and should check if the group is empty, and if so, remove it from the database.