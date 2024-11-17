namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IThenGGuIncludeUser
    {
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IIncludeSender IncludeSender(string path = "Sender");
    }
}
