namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IIncludeGroup
    {
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IIncludeSender IncludeSender(string path = "Sender");
    }
}
