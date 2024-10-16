namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.TransactionGroupUserEntity.Interfaces
{
    public interface IIncludeTransaction
    {
        IIncludeGroupUser IncludeGroupUser(string path = "GroupUser");
    }
}
