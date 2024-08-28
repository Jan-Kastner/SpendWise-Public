using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class CategoryQueryObject : QueryObject<CategoryEntity>
    {
        // Metody pro AND operace

        public CategoryQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public CategoryQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        public CategoryQueryObject WithColor(string color)
        {
            And(entity => entity.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            return this;
        }

        public CategoryQueryObject WithDescription(string description)
        {
            And(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public CategoryQueryObject WithNullDescription()
        {
            And(entity => entity.Description == null);
            return this;
        }

        public CategoryQueryObject WithIcon()
        {
            And(entity => entity.Icon != null);
            return this;
        }

        public CategoryQueryObject WithoutIcon()
        {
            And(entity => entity.Icon == null);
            return this;
        }

        public CategoryQueryObject WithNamePartialMatch(string text)
        {
            And(entity => entity.Name.Contains(text));
            return this;
        }

        public CategoryQueryObject WithDescriptionPartialMatch(string text)
        {
            And(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }

        // Metody pro OR operace

        public CategoryQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public CategoryQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        public CategoryQueryObject OrWithColor(string color)
        {
            Or(entity => entity.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            return this;
        }

        public CategoryQueryObject OrWithDescription(string description)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public CategoryQueryObject OrWithNullDescription()
        {
            Or(entity => entity.Description == null);
            return this;
        }

        public CategoryQueryObject OrWithIcon()
        {
            Or(entity => entity.Icon != null);
            return this;
        }

        public CategoryQueryObject OrWithoutIcon()
        {
            Or(entity => entity.Icon == null);
            return this;
        }

        public CategoryQueryObject OrWithNamePartialMatch(string text)
        {
            Or(entity => entity.Name.Contains(text));
            return this;
        }

        public CategoryQueryObject OrWithDescriptionPartialMatch(string text)
        {
            Or(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }

        // Metody pro NOT operace

        public CategoryQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public CategoryQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        public CategoryQueryObject NotWithColor(string color)
        {
            Not(entity => entity.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
            return this;
        }

        public CategoryQueryObject NotWithDescription(string description)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(description));
            return this;
        }

        public CategoryQueryObject NotWithNullDescription()
        {
            Not(entity => entity.Description == null);
            return this;
        }

        public CategoryQueryObject NotWithIcon()
        {
            Not(entity => entity.Icon != null);
            return this;
        }

        public CategoryQueryObject NotWithoutIcon()
        {
            Not(entity => entity.Icon == null);
            return this;
        }

        public CategoryQueryObject NotWithNamePartialMatch(string text)
        {
            Not(entity => entity.Name.Contains(text));
            return this;
        }

        public CategoryQueryObject NotWithDescriptionPartialMatch(string text)
        {
            Not(entity => entity.Description != null && entity.Description.Contains(text));
            return this;
        }
    }
}
