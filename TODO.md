# TODO.md

## Tasks and Notes

### Additional Tasks

# TODO List

- [ ] **Sender and reciever must be different**

- [ ] **Add Logic for Removing Transactions**

  - **Description**: Implement logic in the repository to ensure that all transactions without any references to `TransactionGroupUser` are removed from the database. This logic should be part of the application and perform regular database maintenance to ensure that only valid transactions with corresponding links remain.

- [ ] **Implement DTOs for Property Update Restrictions**

  - **Description**: Implement logic within DTOs to ensure that certain properties of entities are not updatable. This involves defining which properties are allowed to be updated in the DTOs and ensuring that changes to these properties are not made. This logic should be applied to all relevant entities, including but not limited to `GroupUserEntity`. Implement the corresponding DTOs and validation logic to precisely control which properties can be modified.

- [ ] **Add Logic for Removing Groups After Last Member Removal**

  - **Description**: Implement logic in the application code to ensure that a group is removed if its last member (`GroupUser`) is deleted. This logic should be part of the user removal process from a group and should check if the group is empty, and if so, remove it from the database.

- [ ] **Ensure Each Group Has At Least One Member**

  - **Description**: Implement logic to ensure that a group cannot be created or saved unless it contains at least one `GroupUser`. This logic should be part of the application code and can be implemented in the business logic layer or validation logic to enforce that a group must always have at least one member before it can be persisted to the database.

# TODO List for `UnitOfWorkGroupUserTests`

## CRUD Operations Tests

- [x] **InsertGroupUser_AddsGroupUserToDatabase**

  - Test, zda vložení nové relace skupina-uživatel s platnými daty správně přidá relaci do databáze.

- [x] **GetGroupUserById_ReturnsCorrectGroupUser**
  - Test, zda načtení relace skupina-uživatel podle existujícího ID vrací správnou relaci.
- [x] **DeleteGroupUser_RemovesGroupUserFromDatabase**
  - Test, zda smazání relace skupina-uživatel podle existujícího ID správně odstraní relaci z databáze.

## Error Handling Tests

- [x] **InsertGroupUser_DuplicateUserIdAndGroupId_ThrowsException**

  - Ověření, že pokus o vložení duplicitní kombinace UserId a GroupId vyvolá odpovídající výjimku.

- [x] **GetGroupUserById_InvalidId_ReturnsNull**

  - Ověření, že načtení relace GroupUserEntity s neplatným ID vrátí hodnotu null.

- [x] **DeleteGroupUser_NonExistentId_ThrowsException**
  - Ověření, že pokus o smazání GroupUserEntity s neexistujícím ID vyvolá výjimku.

## Data Retrieval Tests

- [x] **GetAllGroupUsers_ReturnsAllUsers**

  - Test, zda načtení všech GroupUserEntities z databáze vrací správný seznam uživatelů.

- [x] **GetGroupUsersByGroupId_ReturnsUsersInGroup**

  - Test, zda načtení GroupUserEntities podle GroupId vrací správný seznam uživatelů patřících do této skupiny.

- [x] **GetGroupUsersByUserId_ReturnsUsersForUser**
  - Test, zda načtení GroupUserEntities podle UserId vrací správný seznam relací skupina-uživatel pro konkrétního uživatele.

## Update and Special Cases Tests

- [x] **UpdateGroupUser_AttemptToUpdateUserOrGroupId_DoesNotChange**

  - Ověření, že pokus o aktualizaci UserId nebo GroupId existující GroupUserEntity nevede ke změně těchto vlastností.

- [x] **InsertGroupUser_WithInvalidData_ThrowsException**
  - Ověření, že pokus o vložení GroupUserEntity s neplatnými daty (např. null UserId nebo GroupId) vyvolá výjimku.

## Related Entities Handling Tests

- [x] **DeleteGroupUser_WithLimit_ShouldRemoveLimit**

  - Test, zda smazání GroupUserEntity s přidruženým LimitEntity správně odstraní také LimitEntity.

- [x] **DeleteGroupUser_WithoutLimit_ShouldNotAffectRelatedEntities**

  - Test, zda smazání GroupUserEntity bez přidruženého LimitEntity neovlivní příslušné UserEntity a GroupEntity.

- [x] **DeleteGroupUser_WithActiveTransactions_ShouldHandleProperly**
  - Test, zda smazání relace skupina-uživatel s aktivními transakcemi správně odstraní relaci i přidružené transakce.

## Transactional and Referential Integrity Tests

- [x] **TransactionalConsistency_AfterMultipleOperations**

  - Ověření, že vložení, aktualizace a smazání GroupUserEntity je správně zpracováno v transakčním kontextu.

- [ ] **DataIntegrity_ReferentialIntegrity**
  - Ověření, že referenční integrita je zachována pro GroupUserEntity a její příslušné entity.

## CRUD Operations

- [x] Implement functionality to insert a new group and ensure it is added to the database.

  - **Test:** `InsertGroup_AddsGroupToDatabase`

- [x] Implement functionality to fetch a group by its ID and ensure the correct group is returned.

  - **Test:** `GetGroupById_ReturnsCorrectGroup`

- [x] Implement functionality to update an existing group and ensure the group is correctly updated in the database.

  - **Test:** `UpdateGroup_UpdatesGroupInDatabase`

- [x] Implement functionality to delete a group by its ID and ensure the group is removed from the database.
  - **Test:** `DeleteGroup_RemovesGroupFromDatabase`

## Error Handling

- [x] Ensure that attempting to update a non-existent group results in failure.

  - **Test:** `UpdateGroup_NonExistentGroup_ShouldFail`

- [x] Ensure that attempting to delete a non-existent group results in failure.
  - **Test:** `DeleteGroup_NonExistentGroup_ShouldFail`

## Data Retrieval

- [x] Implement functionality to fetch all groups and ensure the correct number of groups is returned, including all seeded groups.

  - **Test:** `GetAllGroups_ShouldReturnAllGroups`

- [x] Implement functionality to fetch a group by its name and ensure the correct group is returned.

  - **Test:** `GetGroupByName_ReturnsCorrectGroup`

- [x] Implement functionality to fetch a group by its description and ensure the correct group is returned.
  - **Test:** `GetGroupByDescription_ReturnsCorrectGroup`

## Update and Special Cases

- [x] Implement functionality to update a group’s name and description, ensuring both fields are correctly updated.

  - **Test:** `UpdateGroup_ChangeNameAndDescription_ShouldUpdateBoth`

- [x] Implement functionality to allow updating a group with an empty description.

  - **Test:** `UpdateGroup_WithEmptyDescription_ShouldBeAllowed`

- [x] Ensure that creating a group with special characters in the name is successfully handled.
  - **Test:** `CreateGroup_WithSpecialCharactersInName_ShouldSucceed`

## Related Entities Handling

- [x] Ensure that deleting a group with active invitations is handled properly by removing the group and its related invitations.

  - **Test:** `DeleteGroup_WithActiveInvitations_ShouldHandleProperly`

- [x] Ensure that deleting a group with active users correctly removes all associated users from the group.
  - **Test:** `DeleteGroup_WithActiveUsers_ShouldRemoveAllAssociatedUsers`

## Consistency Tests

- [x] Ensure that a group remains consistent after multiple updates.
  - **Test:** `UpdateGroup_ConsistencyAfterMultipleUpdates`

## CRUD Operations Tests

- [x] **InsertInvitation_AddsInvitationToDatabase**

  - Test, zda vložení nové pozvánky (InvitationEntity) s platnými daty správně přidá pozvánku do databáze.

- [x] **GetInvitationById_ReturnsCorrectInvitation**

  - Test, zda načtení pozvánky podle existujícího ID vrací správnou pozvánku.

- [x] **DeleteInvitation_RemovesInvitationFromDatabase**

  - Test, zda smazání pozvánky podle existujícího ID správně odstraní pozvánku z databáze.

- [x] **UpdateInvitation_UpdatesInvitationInDatabase**

  - Test, zda aktualizace pozvánky s platnými daty správně aktualizuje pozvánku v databáze.

## Error Handling Tests

- [x] **InsertInvitation_DuplicateInvitation_ThrowsException**

  - Ověření, že pokus o vložení duplicity pozvánky (shodné `SenderId`, `ReceiverId` a `GroupId`) vyvolá odpovídající výjimku.

- [x] **GetInvitationById_InvalidId_ReturnsNull**
  - Ověření, že načtení pozvánky s neplatným ID vrátí hodnotu null.
- [x] **DeleteInvitation_NonExistentId_ThrowsException**

  - Ověření, že pokus o smazání pozvánky s neexistujícím ID vyvolá výjimku.

- [x] **UpdateInvitation_NonExistentInvitation_ThrowsException**

  - Ověření, že pokus o aktualizaci neexistující pozvánky vyvolá výjimku.

## Data Retrieval Tests

- [ ] **GetAllInvitations_ReturnsAllInvitations**

  - Test, zda načtení všech pozvánek z databáze vrací správný seznam pozvánek.

- [ ] **GetInvitationsByGroupId_ReturnsInvitationsForGroup**

  - Test, zda načtení pozvánek podle GroupId vrací správný seznam pozvánek patřících do této skupiny.

- [ ] **GetInvitationsBySenderId_ReturnsInvitationsFromSender**

  - Test, zda načtení pozvánek podle SenderId vrací správný seznam pozvánek odeslaných daným uživatelem.

- [ ] **GetInvitationsByReceiverId_ReturnsInvitationsToReceiver**

  - Test, zda načtení pozvánek podle ReceiverId vrací správný seznam pozvánek určených pro daného uživatele.

## Update and Special Cases Tests

- [ ] **UpdateInvitation_AttemptToChangeSenderOrReceiver_ShouldNotChange**

  - Ověření, že pokus o aktualizaci `SenderId` nebo `ReceiverId` existující pozvánky nevede ke změně těchto vlastností.

- [ ] **InsertInvitation_WithInvalidData_ThrowsException**

  - Ověření, že pokus o vložení pozvánky s neplatnými daty (např. null `SenderId`, `ReceiverId` nebo `GroupId`) vyvolá výjimku.

## Related Entities Handling Tests

- [ ] **DeleteInvitation_WithAssociatedEntities_ShouldHandleProperly**

  - Test, zda smazání pozvánky správně zachází s přidruženými entitami (např. uživatelé, skupiny).

- [ ] **DeleteInvitation_WithoutAssociatedEntities_ShouldNotAffectRelatedEntities**

  - Test, zda smazání pozvánky bez přidružených entit neovlivní příslušné UserEntity a GroupEntity.

## Transactional and Referential Integrity Tests

- [ ] **TransactionalConsistency_AfterMultipleOperations**

  - Ověření, že vložení, aktualizace a smazání InvitationEntity je správně zpracováno v transakčním kontextu.

- [ ] **DataIntegrity_ReferentialIntegrity**

  - Ověření, že referenční integrita je zachována pro InvitationEntity a její příslušné entity.

## Special Cases and Edge Scenarios

- [ ] **InsertInvitation_WithNullResponseDate_ShouldSucceed**

  - Ověření, že vložení pozvánky s nulovou hodnotou `ResponseDate` je úspěšné.

- [ ] **UpdateInvitation_SetResponseDateAndIsAccepted_ShouldSucceed**

  - Test, zda aktualizace pozvánky s nastavením `ResponseDate` a `IsAccepted` správně uloží tyto hodnoty.

- [ ] **InsertInvitation_WithPastSentDate_ShouldSucceed**

  - Test, zda vložení pozvánky s datem odeslání (`SentDate`) v minulosti je úspěšné.
