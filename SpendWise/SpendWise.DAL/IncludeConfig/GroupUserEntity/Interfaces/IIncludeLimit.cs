namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeLimit
    {
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeUser IncludeUser(string path = "User");
    }
}
