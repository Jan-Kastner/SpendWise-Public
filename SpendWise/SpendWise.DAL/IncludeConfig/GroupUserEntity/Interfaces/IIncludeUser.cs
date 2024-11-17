namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeUser
    {
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeLimit IncludeLimit(string path = "Limit");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
