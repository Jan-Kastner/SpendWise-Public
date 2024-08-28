using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class GroupUserQueryObject : QueryObject<GroupUserEntity>
    {
        // Metody pro AND operace

        public GroupUserQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public GroupUserQueryObject WithUserId(Guid userId)
        {
            And(entity => entity.UserId == userId);
            return this;
        }

        public GroupUserQueryObject WithGroupId(Guid groupId)
        {
            And(entity => entity.GroupId == groupId);
            return this;
        }

        public GroupUserQueryObject WithLimitId(Guid? limitId)
        {
            And(entity => entity.LimitId == limitId);
            return this;
        }

        public GroupUserQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        // Metody pro OR operace

        public GroupUserQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public GroupUserQueryObject OrWithUserId(Guid userId)
        {
            Or(entity => entity.UserId == userId);
            return this;
        }

        public GroupUserQueryObject OrWithGroupId(Guid groupId)
        {
            Or(entity => entity.GroupId == groupId);
            return this;
        }

        public GroupUserQueryObject OrWithLimitId(Guid? limitId)
        {
            Or(entity => entity.LimitId == limitId);
            return this;
        }

        public GroupUserQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        // Metody pro NOT operace

        public GroupUserQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public GroupUserQueryObject NotWithUserId(Guid userId)
        {
            Not(entity => entity.UserId == userId);
            return this;
        }

        public GroupUserQueryObject NotWithGroupId(Guid groupId)
        {
            Not(entity => entity.GroupId == groupId);
            return this;
        }

        public GroupUserQueryObject NotWithLimitId(Guid? limitId)
        {
            Not(entity => entity.LimitId == limitId);
            return this;
        }

        public GroupUserQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }
    }
}
