namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IThenGIncludeGroupUsers
    {
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IThenGGuIncludeUser ThenGGuIncludeUser(string path = "Group.GroupUsers.User");
        IIncludeSender IncludeSender(string path = "Sender");
    }
}
