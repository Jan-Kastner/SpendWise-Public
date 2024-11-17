namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuIncludeUser
    {
        IThenGuIncludeTransactionGroupUsers ThenGuIncludeTransactionGroupUsers(string path = "GroupUsers.TransactionGroupUsers");
    }
}
