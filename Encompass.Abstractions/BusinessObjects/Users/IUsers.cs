using System;
using System.Collections;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;
using IUser = Encompass.Abstractions.BusinessObjects.Users.IUser;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public interface IUsers
    {    
        UserGroups Groups { get; }

        Personas Personas { get; }

        ISession Session { get; }

        UserList GetAllUsers();

        UserList GetUsersWithPersona(Persona persona, bool exactMatch);

        IUser GetUser(string userId);

        ExternalUser GetExternalUserByEmailandSiteID(string loginEmail, string SiteID);

        ExternalUser GetExternalUserByExternalID(string externalUserID);

        ExternalUser GetExternalUserByContactID(string contactID);

        ExternalUser ValidateExternalUserBySiteID(string loginEmail, string password, string siteID);

        ArrayList GetTPOWCAEView(IUser aeUser, int urlID);

    }
}
