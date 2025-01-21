namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IIncludeSender
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
    }
}
