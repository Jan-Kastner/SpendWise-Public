namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IInvitationEntityInitialState
    {
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IIncludeSender IncludeSender(string path = "Sender");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
