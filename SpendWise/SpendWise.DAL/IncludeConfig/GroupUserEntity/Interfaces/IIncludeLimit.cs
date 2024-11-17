namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeLimit
    {
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeUser IncludeUser(string path = "User");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
