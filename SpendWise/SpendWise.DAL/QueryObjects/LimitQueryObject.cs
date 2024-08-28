using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class LimitQueryObject : QueryObject<LimitEntity>
    {
        // Metody pro AND operace

        public LimitQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public LimitQueryObject WithGroupUserId(Guid groupUserId)
        {
            And(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        public LimitQueryObject WithAmount(decimal amount)
        {
            And(entity => entity.Amount == amount);
            return this;
        }

        public LimitQueryObject WithNoticeType(int noticeType)
        {
            And(entity => entity.NoticeType == noticeType);
            return this;
        }

        // Metody pro OR operace

        public LimitQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public LimitQueryObject OrWithGroupUserId(Guid groupUserId)
        {
            Or(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        public LimitQueryObject OrWithAmount(decimal amount)
        {
            Or(entity => entity.Amount == amount);
            return this;
        }

        public LimitQueryObject OrWithNoticeType(int noticeType)
        {
            Or(entity => entity.NoticeType == noticeType);
            return this;
        }

        // Metody pro NOT operace

        public LimitQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public LimitQueryObject NotWithGroupUserId(Guid groupUserId)
        {
            Not(entity => entity.GroupUserId == groupUserId);
            return this;
        }

        public LimitQueryObject NotWithAmount(decimal amount)
        {
            Not(entity => entity.Amount == amount);
            return this;
        }

        public LimitQueryObject NotWithNoticeType(int noticeType)
        {
            Not(entity => entity.NoticeType == noticeType);
            return this;
        }
    }
}
