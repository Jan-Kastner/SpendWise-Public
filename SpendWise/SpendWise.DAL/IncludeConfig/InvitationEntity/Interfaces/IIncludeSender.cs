namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IIncludeSender
    {
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
