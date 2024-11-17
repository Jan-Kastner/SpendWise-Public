namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeGroup
    {
        IIncludeUser IncludeUser(string path = "User");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
    }
}
