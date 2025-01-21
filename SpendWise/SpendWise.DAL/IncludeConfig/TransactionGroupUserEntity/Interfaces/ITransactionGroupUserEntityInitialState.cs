namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface ITransactionGroupUserEntityInitialState
    {
        IIncludeTransaction IncludeTransaction(string path = "Transaction");
    }
}
