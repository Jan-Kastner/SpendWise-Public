namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.UserEntity.Interfaces
{
    public interface IThenGuIncludeGroup
    {
        IIncludeReceivedInvitations IncludeReceivedInvitations(string path = "ReceivedInvitations");
        IIncludeSentInvitations IncludeSentInvitations(string path = "SentInvitations");
    }
}
