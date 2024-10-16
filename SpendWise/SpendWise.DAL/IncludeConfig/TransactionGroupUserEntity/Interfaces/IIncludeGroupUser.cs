namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface IIncludeGroupUser
    {
        IThenGuIncludeUser ThenGuIncludeUser(string path = "GroupUser.User");
        IIncludeTransaction IncludeTransaction(string path = "Transaction");
    }
}
