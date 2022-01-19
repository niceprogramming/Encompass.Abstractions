using System;
using System.Collections;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;
using IUser = Encompass.Abstractions.BusinessObjects.Users.IUser;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public class UsersWrapper : IUsers
    {
        private readonly EllieMae.Encompass.BusinessObjects.Users.Users _users;

        public UsersWrapper(EllieMae.Encompass.BusinessObjects.Users.Users value)
        {
            _users = value; 


        }

        public UserGroups Groups => _users.Groups;

        public Personas Personas => _users.Personas;

        public ISession Session => (SessionWrapper) _users.Session;

        public UserList GetAllUsers() => _users.GetAllUsers();

        public UserList GetUsersWithPersona(Persona persona, bool exactMatch) => _users.GetUsersWithPersona(persona, exactMatch);

        public IUser GetUser(string userId) => (UserWrapper) _users.GetUser(userId);

        public ExternalUser GetExternalUserByEmailandSiteID(string loginEmail, string SiteID) => _users.GetExternalUserByEmailandSiteID(loginEmail, SiteID);

        public ExternalUser GetExternalUserByExternalID(string externalUserID) => _users.GetExternalUserByExternalID(externalUserID);

        public ExternalUser GetExternalUserByContactID(string contactID) => _users.GetExternalUserByContactID(contactID);

        public ExternalUser ValidateExternalUserBySiteID(string loginEmail, string password, string siteID) => _users.ValidateExternalUserBySiteID(loginEmail, password, siteID);

        public ArrayList GetTPOWCAEView(IUser aeUser, int urlID) => _users.GetTPOWCAEView((UserWrapper) aeUser, urlID);

        public static implicit operator UsersWrapper(EllieMae.Encompass.BusinessObjects.Users.Users value) => new UsersWrapper(value);
        public static implicit operator EllieMae.Encompass.BusinessObjects.Users.Users(UsersWrapper value) => value._users;
    }
}
