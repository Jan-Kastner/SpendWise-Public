namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeLimit
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeUser IncludeUser(string path = "User");
    }
}
