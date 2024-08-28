using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class InvitationQueryObject : QueryObject<InvitationEntity>
    {
        // Metody pro AND operace

        public InvitationQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public InvitationQueryObject WithSenderId(Guid senderId)
        {
            And(entity => entity.SenderId == senderId);
            return this;
        }

        public InvitationQueryObject WithReceiverId(Guid receiverId)
        {
            And(entity => entity.ReceiverId == receiverId);
            return this;
        }

        public InvitationQueryObject WithGroupId(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        public InvitationQueryObject WithSentDate(DateTime sentDate)
        {
            And(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        public InvitationQueryObject WithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                And(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        public InvitationQueryObject WithIsAccepted(bool? isAccepted)
        {
            And(entity => entity.IsAccepted == isAccepted);
            return this;
        }

        // Metody pro OR operace

        public InvitationQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public InvitationQueryObject OrWithSenderId(Guid senderId)
        {
            Or(entity => entity.SenderId == senderId);
            return this;
        }

        public InvitationQueryObject OrWithReceiverId(Guid receiverId)
        {
            Or(entity => entity.ReceiverId == receiverId);
            return this;
        }

        public InvitationQueryObject OrWithGroupId(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        public InvitationQueryObject OrWithSentDate(DateTime sentDate)
        {
            Or(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        public InvitationQueryObject OrWithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                Or(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        public InvitationQueryObject OrWithIsAccepted(bool? isAccepted)
        {
            Or(entity => entity.IsAccepted == isAccepted);
            return this;
        }

        // Metody pro NOT operace

        public InvitationQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public InvitationQueryObject NotWithSenderId(Guid senderId)
        {
            Not(entity => entity.SenderId == senderId);
            return this;
        }

        public InvitationQueryObject NotWithReceiverId(Guid receiverId)
        {
            Not(entity => entity.ReceiverId == receiverId);
            return this;
        }

        public InvitationQueryObject NotWithGroupId(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        public InvitationQueryObject NotWithSentDate(DateTime sentDate)
        {
            Not(entity => entity.SentDate.Date == sentDate.Date);
            return this;
        }

        public InvitationQueryObject NotWithResponseDate(DateTime? responseDate)
        {
            if (responseDate.HasValue)
            {
                Not(entity => entity.ResponseDate.HasValue && entity.ResponseDate.Value.Date == responseDate.Value.Date);
            }
            return this;
        }

        public InvitationQueryObject NotWithIsAccepted(bool? isAccepted)
        {
            Not(entity => entity.IsAccepted == isAccepted);
            return this;
        }
    }
}
