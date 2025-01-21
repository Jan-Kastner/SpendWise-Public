namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IIncludeGroupUsers
    {
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUsers.User");
    }
}
