using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class TransactionQueryObject : QueryObject<TransactionEntity>
    {
        // Metody pro AND operace

        public TransactionQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public TransactionQueryObject WithAmount(decimal amount)
        {
            And(entity => entity.Amount == amount);
            return this;
        }

        public TransactionQueryObject WithDate(DateTime date)
        {
            And(entity => entity.Date.Date == date.Date);
            return this;
        }

        public TransactionQueryObject WithDescription(string description)
        {
            And(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public TransactionQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        public TransactionQueryObject WithType(int type)
        {
            And(entity => entity.Type == type);
            return this;
        }

        public TransactionQueryObject WithCategoryId(Guid? categoryId)
        {
            And(entity => entity.CategoryId == categoryId);
            return this;
        }

        public TransactionQueryObject WithTransactionGroupUser(Guid transactionGroupUserId)
        {
            And(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        // Metody pro OR operace

        public TransactionQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public TransactionQueryObject OrWithAmount(decimal amount)
        {
            Or(entity => entity.Amount == amount);
            return this;
        }

        public TransactionQueryObject OrWithDate(DateTime date)
        {
            Or(entity => entity.Date.Date == date.Date);
            return this;
        }

        public TransactionQueryObject OrWithDescription(string description)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public TransactionQueryObject OrWithType(int type)
        {
            Or(entity => entity.Type == type);
            return this;
        }

        public TransactionQueryObject OrWithCategoryId(Guid? categoryId)
        {
            Or(entity => entity.CategoryId == categoryId);
            return this;
        }

        public TransactionQueryObject OrWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Or(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }

        // Metody pro NOT operace

        public TransactionQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public TransactionQueryObject NotWithAmount(decimal amount)
        {
            Not(entity => entity.Amount == amount);
            return this;
        }

        public TransactionQueryObject NotWithDate(DateTime date)
        {
            Not(entity => entity.Date.Date == date.Date);
            return this;
        }

        public TransactionQueryObject NotWithDescription(string description)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public TransactionQueryObject NotWithType(int type)
        {
            Not(entity => entity.Type == type);
            return this;
        }

        public TransactionQueryObject NotWithCategoryId(Guid? categoryId)
        {
            Not(entity => entity.CategoryId == categoryId);
            return this;
        }

        public TransactionQueryObject NotWithTransactionGroupUser(Guid transactionGroupUserId)
        {
            Not(entity => entity.TransactionGroupUsers.Any(tgu => tgu.Id == transactionGroupUserId));
            return this;
        }
    }
}
