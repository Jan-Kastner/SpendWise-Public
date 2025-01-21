namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IIncludeReceiver
    {
        IIncludeGroup IncludeGroup(string path = "Group");
        IIncludeSender IncludeSender(string path = "Sender");
    }
}
