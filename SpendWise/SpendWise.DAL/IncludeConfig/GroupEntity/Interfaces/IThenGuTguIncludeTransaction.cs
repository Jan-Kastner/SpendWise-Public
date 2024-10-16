namespace SpendWise.SpendWise.DAL.IncludeConfig.RelationsConfig.GroupEntity.Interfaces
{
    public interface IThenGuTguIncludeTransaction
    {
        IIncludeInvitations IncludeInvitations(string path = "Invitations");
    }
}
