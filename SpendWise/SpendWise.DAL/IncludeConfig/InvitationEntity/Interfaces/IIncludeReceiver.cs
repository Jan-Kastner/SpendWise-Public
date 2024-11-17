namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IIncludeReceiver
    {
        IIncludeSender IncludeSender(string path = "Sender");
        IIncludeGroup IncludeGroup(string path = "Group");
    }
}
