namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeUser
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeLimit IncludeLimit(string path = "Limit");
    }
}
