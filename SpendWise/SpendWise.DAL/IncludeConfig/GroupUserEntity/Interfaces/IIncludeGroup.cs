namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeGroup
    {
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeUser IncludeUser(string path = "User");
    }
}
