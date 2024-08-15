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

## 1. Testy CRUD Operací

- [ ] **Create Testy**

  - [ ] Ověř, že můžeš úspěšně vložit nového `GroupUserEntity` do databáze.
  - [ ] Ověř, že se správně uloží všechny povinné vlastnosti (`Id`, `UserId`, `GroupId`).
  - [ ] Ověř, že se při vytvoření `GroupUserEntity` správně nastaví výchozí hodnoty, pokud existují.

- [ ] **Read Testy**

  - [ ] Ověř, že můžeš úspěšně načíst `GroupUserEntity` podle jeho `Id`.
  - [ ] Ověř, že načtení `GroupUserEntity` vrátí správné související entity (např. `User`, `Group`, `Limit`).
  - [ ] Ověř, že načtení více `GroupUserEntity` podle `GroupId` vrátí správný seznam entit.

- [ ] **Update Testy**

  - [ ] Ověř, že můžeš úspěšně aktualizovat existující `GroupUserEntity`.
  - [ ] Ověř, že aktualizace změn v `GroupUserEntity` se správně promítnou do databáze.
  - [ ] Ověř, že při aktualizaci `GroupUserEntity` se všechny závislé entity aktualizují správně (např. `Limit`).

- [ ] **Delete Testy**
  - [ ] Ověř, že můžeš úspěšně smazat `GroupUserEntity` podle jeho `Id`.
  - [ ] Ověř, že po smazání není entita stále přítomná v databázi.
  - [ ] Ověř, že při smazání `GroupUserEntity` se správně zpracovávají závislé entity (např. `TransactionGroupUserEntity`).

## 2. Testy Validace

- [ ] **Validace Id**

  - [ ] Ověř, že `Id` musí být vyplněno a je unikátní.
  - [ ] Ověř, že `Id` odpovídá formátu UUID, pokud je použit.

- [ ] **Validace UserId a GroupId**

  - [ ] Ověř, že `UserId` a `GroupId` jsou povinné a musí existovat v odpovídajících tabulkách.
  - [ ] Ověř, že neexistují žádné `GroupUserEntity` s neexistujícím `UserId` nebo `GroupId`.

- [ ] **Validace Limit**
  - [ ] Ověř, že `Limit` může být `null` a že aplikace správně zpracovává případy, kdy není definováno.
  - [ ] Ověř, že `Limit` správně reaguje na změny v `GroupUserEntity`.

## 3. Testy Relací

- [ ] **Testy Relací `User`**

  - [ ] Ověř, že při načtení `GroupUserEntity` je správně načtena související `UserEntity`.
  - [ ] Ověř, že změny v `UserEntity` se správně odrážejí v `GroupUserEntity`.
  - [ ] Ověř, že při smazání `UserEntity` se správně zpracovávají závislé `GroupUserEntity`.

- [ ] **Testy Relací `Group`**

  - [ ] Ověř, že při načtení `GroupUserEntity` je správně načtena související `GroupEntity`.
  - [ ] Ověř, že změny v `GroupEntity` se správně odrážejí v `GroupUserEntity`.
  - [ ] Ověř, že při smazání `GroupEntity` se správně zpracovávají závislé `GroupUserEntity`.

- [ ] **Testy Relací `Limit`**
  - [ ] Ověř, že při načtení `GroupUserEntity` s definovaným `Limit` je správně načtena související `LimitEntity`.
  - [ ] Ověř, že absence `Limit` je správně zpracována.
  - [ ] Ověř, že změny v `LimitEntity` se správně odrážejí v `GroupUserEntity`.

## 4. Testy Seedu

- [ ] **Testy Seed Data**
  - [ ] Ověř, že seed data pro `GroupUserEntity` jsou správně inicializována v databázi.
  - [ ] Ověř, že seedy obsahují všechny potřebné vztahy a údaje.
  - [ ] Ověř, že seed data neporušují žádné entity constrainty nebo unikátnost.

## 5. Testy Repozitáře

- [ ] **Testy Repozitářů**
  - [ ] Ověř, že repozitář správně implementuje CRUD operace pro `GroupUserEntity`.
  - [ ] Ověř, že metody repozitáře jako `InsertAsync`, `UpdateAsync`, `DeleteAsync` a `GetByIdAsync` fungují správně.
  - [ ] Ověř, že repozitář správně zpracovává transakce a rollbacky při chybách.

## 6. Testy UnitOfWork

- [ ] **Testy UnitOfWork**
  - [ ] Ověř, že `UnitOfWork` správně koordinuje operace s repozitářem `GroupUsers`.
  - [ ] Ověř, že `SaveChangesAsync` správně uloží změny do databáze.
  - [ ] Ověř, že `DisposeAsync` správně uvolní zdroje.
  - [ ] Ověř, že `UnitOfWork` správně zachází s vícenásobnými operacemi a zajišťuje konzistenci dat.

## 7. Testy Výkonu

- [ ] **Testy Výkonu**
  - [ ] Ověř, že CRUD operace na `GroupUserEntity` jsou efektivní a splňují očekávané výkonnostní standardy.
  - [ ] Ověř, že načítání a aktualizace `GroupUserEntity` nezpůsobují významné zpoždění nebo bottlenecks.

## 8. Testy Bezpečnosti

- [ ] **Testy Bezpečnosti**
  - [ ] Ověř, že `GroupUserEntity` a jeho operace jsou chráněny proti neoprávněnému přístupu.
  - [ ] Ověř, že všechny citlivé údaje jsou správně šifrovány a chráněny.
  - [ ] Ověř, že jsou implementována odpovídající bezpečnostní opatření proti SQL Injection a jiným bezpečnostním hrozbám.
