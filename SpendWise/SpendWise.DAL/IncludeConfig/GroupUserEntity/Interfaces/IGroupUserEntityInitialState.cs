namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IGroupUserEntityInitialState
    {
        IIncludeUser IncludeUser(string path = "User");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
