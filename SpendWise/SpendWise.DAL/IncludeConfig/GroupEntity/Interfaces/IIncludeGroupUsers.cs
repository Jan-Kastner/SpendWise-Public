namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IIncludeGroupUsers
    {
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
    }
}
