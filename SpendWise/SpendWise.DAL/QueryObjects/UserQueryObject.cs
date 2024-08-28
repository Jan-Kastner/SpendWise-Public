using System;
using System.Linq.Expressions;
using SpendWise.DAL.Entities;
using SpendWise.DAL.QueryObjects;

namespace SpendWise.DAL.QueryObjects
{
    public class UserQueryObject : QueryObject<UserEntity>
    {
        // Metody pro AND operace

        public UserQueryObject WithId(Guid id)
        {
            And(entity => entity.Id == id);
            return this;
        }

        public UserQueryObject WithName(string name)
        {
            And(entity => entity.Name.Contains(name));
            return this;
        }

        public UserQueryObject WithSurname(string surname)
        {
            And(entity => entity.Surname.Contains(surname));
            return this;
        }

        public UserQueryObject WithEmail(string email)
        {
            And(entity => entity.Email.Contains(email));
            return this;
        }

        public UserQueryObject WithPassword(string password)
        {
            And(entity => entity.Password.Contains(password));
            return this;
        }

        public UserQueryObject WithDateOfRegistration(DateTime dateOfRegistration)
        {
            And(entity => entity.Date_of_registration.Date == dateOfRegistration.Date);
            return this;
        }

        public UserQueryObject WithPhoto()
        {
            And(entity => entity.Photo != null);
            return this;
        }

        public UserQueryObject WithoutPhoto()
        {
            And(entity => entity.Photo == null);
            return this;
        }

        public UserQueryObject WithSentInvitation(Guid invitationId)
        {
            And(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject WithReceivedInvitation(Guid invitationId)
        {
            And(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject WithGroupUser(Guid groupUserId)
        {
            And(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        // Metody pro OR operace

        public UserQueryObject OrWithId(Guid id)
        {
            Or(entity => entity.Id == id);
            return this;
        }

        public UserQueryObject OrWithName(string name)
        {
            Or(entity => entity.Name.Contains(name));
            return this;
        }

        public UserQueryObject OrWithSurname(string surname)
        {
            Or(entity => entity.Surname.Contains(surname));
            return this;
        }

        public UserQueryObject OrWithEmail(string email)
        {
            Or(entity => entity.Email.Contains(email));
            return this;
        }

        public UserQueryObject OrWithPassword(string password)
        {
            Or(entity => entity.Password.Contains(password));
            return this;
        }

        public UserQueryObject OrWithDateOfRegistration(DateTime dateOfRegistration)
        {
            Or(entity => entity.Date_of_registration.Date == dateOfRegistration.Date);
            return this;
        }

        public UserQueryObject OrWithPhoto()
        {
            Or(entity => entity.Photo != null);
            return this;
        }

        public UserQueryObject OrWithoutPhoto()
        {
            Or(entity => entity.Photo == null);
            return this;
        }

        public UserQueryObject OrWithSentInvitation(Guid invitationId)
        {
            Or(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject OrWithReceivedInvitation(Guid invitationId)
        {
            Or(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject OrWithGroupUser(Guid groupUserId)
        {
            Or(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        // Metody pro NOT operace

        public UserQueryObject NotWithId(Guid id)
        {
            Not(entity => entity.Id == id);
            return this;
        }

        public UserQueryObject NotWithName(string name)
        {
            Not(entity => entity.Name.Contains(name));
            return this;
        }

        public UserQueryObject NotWithSurname(string surname)
        {
            Not(entity => entity.Surname.Contains(surname));
            return this;
        }

        public UserQueryObject NotWithEmail(string email)
        {
            Not(entity => entity.Email.Contains(email));
            return this;
        }

        public UserQueryObject NotWithPassword(string password)
        {
            Not(entity => entity.Password.Contains(password));
            return this;
        }

        public UserQueryObject NotWithDateOfRegistration(DateTime dateOfRegistration)
        {
            Not(entity => entity.Date_of_registration.Date == dateOfRegistration.Date);
            return this;
        }

        public UserQueryObject NotWithPhoto()
        {
            Not(entity => entity.Photo != null);
            return this;
        }

        public UserQueryObject NotWithoutPhoto()
        {
            Not(entity => entity.Photo == null);
            return this;
        }

        public UserQueryObject NotWithSentInvitation(Guid invitationId)
        {
            Not(entity => entity.SentInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject NotWithReceivedInvitation(Guid invitationId)
        {
            Not(entity => entity.ReceivedInvitations.Any(i => i.Id == invitationId));
            return this;
        }

        public UserQueryObject NotWithGroupUser(Guid groupUserId)
        {
            Not(entity => entity.GroupUsers.Any(gu => gu.Id == groupUserId));
            return this;
        }

        // Další užitečné metody

        public UserQueryObject WithFullName(string fullName)
        {
            And(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        public UserQueryObject WithEmailDomain(string domain)
        {
            And(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        public UserQueryObject OrWithFullName(string fullName)
        {
            Or(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        public UserQueryObject OrWithEmailDomain(string domain)
        {
            Or(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }

        public UserQueryObject NotWithFullName(string fullName)
        {
            Not(entity => (entity.Name + " " + entity.Surname).Contains(fullName));
            return this;
        }

        public UserQueryObject NotWithEmailDomain(string domain)
        {
            Not(entity => entity.Email.EndsWith("@" + domain));
            return this;
        }
    }
}
