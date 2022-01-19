using System;
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;
using IStateLicenses = Encompass.Abstractions.BusinessObjects.Users.IStateLicenses;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public interface IUser
    {    
        string ID { get; }

        string Password { get; set; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        string Suffix { get; set; }

        string LastName { get; set; }

        string FullName { get; }

        string EmployeeID { get; set; }

        UserPersonas Personas { get; }

        string JobTitle { get; set; }

        string Email { get; set; }

        string Phone { get; set; }

        string CellPhone { get; set; }

        string Fax { get; set; }

        string WorkingFolder { get; set; }

        bool RequirePasswordChange { get; set; }

        DateTime PasswordChangedDate { get; }

        bool AccountLocked { get; set; }

        string CHUMID { get; set; }

        string NMLSOriginatorID { get; set; }

        DateTime NMLSExpirationDate { get; set; }

        SubordinateLoanAccessRight SubordinateLoanAccessRight { get; set; }

        PeerLoanAccessRight PeerLoanAccessRight { get; set; }

        IStateLicenses StateLicenses { get; }

        int OrganizationID { get; }

        int FailedLoginAttempts { get; }

        bool Enabled { get; }

        bool IsNew { get; }

        bool SSOOnly { get; set; }

        bool SSODisconnectedFromOrg { get; set; }

        ISession Session { get; }

        event EventHandler<IPersistentObjectEventArgs> Committed;

        void ChangeOrganization(Organization newOrganization);

        void Enable();

        void Disable();

        bool HasAccessTo(Feature feature);

        void GrantAccessTo(Feature feature);

        void RevokeAccessTo(Feature feature);

        DataObject GetCustomDataObject(string fileName);

        void SaveCustomDataObject(string fileName, DataObject dataObj);

        void AppendToCustomDataObject(string fileName, DataObject dataObj);

        void DeleteCustomDataObject(string fileName);

        void Commit();

        void Delete();

        void Refresh();

        UserGroupList GetUserGroups();

        string ToString();

    }
}
