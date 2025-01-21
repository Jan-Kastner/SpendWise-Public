namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.InvitationEntity.Interfaces
{
    public interface IThenGIncludeGroupUsers
    {
        IThenGGuIncludeUser ThenGGuIncludeUser(string path = "Group.GroupUsers.User");
        IIncludeReceiver IncludeReceiver(string path = "Receiver");
        IIncludeSender IncludeSender(string path = "Sender");
    }
}
