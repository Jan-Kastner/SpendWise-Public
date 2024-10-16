namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupUserEntity.Interfaces
{
    public interface IIncludeUser
    {
        IIncludeTransactionGroupUsers IncludeTransactionGroupUsers(string path = "TransactionGroupUsers");
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeLimit IncludeLimit(string path = "Limit");
    }
}
