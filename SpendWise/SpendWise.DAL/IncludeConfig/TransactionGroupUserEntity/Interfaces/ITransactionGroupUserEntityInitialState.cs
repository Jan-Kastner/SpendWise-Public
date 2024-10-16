namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface ITransactionGroupUserEntityInitialState
    {
        IIncludeGroupUser IncludeGroupUser(string path = "GroupUser");
        IIncludeTransaction IncludeTransaction(string path = "Transaction");
    }
}
