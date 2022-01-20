using System;
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Collections;
using Encompass.Abstractions.Client;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public class UserWrapper : IUser
    {
        private readonly User _user;

        public UserWrapper(User value)
        {
            _user = value; 

           value.Committed += onCommitted;

        }

        public string ID => _user.ID;

        public string Password
        {
            get => _user.Password;
            set => _user.Password = value;
        }

        public string FirstName
        {
            get => _user.FirstName;
            set => _user.FirstName = value;
        }

        public string MiddleName
        {
            get => _user.MiddleName;
            set => _user.MiddleName = value;
        }

        public string Suffix
        {
            get => _user.Suffix;
            set => _user.Suffix = value;
        }

        public string LastName
        {
            get => _user.LastName;
            set => _user.LastName = value;
        }

        public string FullName => _user.FullName;

        public string EmployeeID
        {
            get => _user.EmployeeID;
            set => _user.EmployeeID = value;
        }

        public UserPersonas Personas => _user.Personas;

        public string JobTitle
        {
            get => _user.JobTitle;
            set => _user.JobTitle = value;
        }

        public string Email
        {
            get => _user.Email;
            set => _user.Email = value;
        }

        public string Phone
        {
            get => _user.Phone;
            set => _user.Phone = value;
        }

        public string CellPhone
        {
            get => _user.CellPhone;
            set => _user.CellPhone = value;
        }

        public string Fax
        {
            get => _user.Fax;
            set => _user.Fax = value;
        }

        public string WorkingFolder
        {
            get => _user.WorkingFolder;
            set => _user.WorkingFolder = value;
        }

        public bool RequirePasswordChange
        {
            get => _user.RequirePasswordChange;
            set => _user.RequirePasswordChange = value;
        }

        public DateTime PasswordChangedDate => _user.PasswordChangedDate;

        public bool AccountLocked
        {
            get => _user.AccountLocked;
            set => _user.AccountLocked = value;
        }

        public string CHUMID
        {
            get => _user.CHUMID;
            set => _user.CHUMID = value;
        }

        public string NMLSOriginatorID
        {
            get => _user.NMLSOriginatorID;
            set => _user.NMLSOriginatorID = value;
        }

        public DateTime NMLSExpirationDate
        {
            get => _user.NMLSExpirationDate;
            set => _user.NMLSExpirationDate = value;
        }

        public SubordinateLoanAccessRight SubordinateLoanAccessRight
        {
            get => _user.SubordinateLoanAccessRight;
            set => _user.SubordinateLoanAccessRight = value;
        }

        public PeerLoanAccessRight PeerLoanAccessRight
        {
            get => _user.PeerLoanAccessRight;
            set => _user.PeerLoanAccessRight = value;
        }

        public StateLicenses StateLicenses => _user.StateLicenses;

        public int OrganizationID => _user.OrganizationID;

        public int FailedLoginAttempts => _user.FailedLoginAttempts;

        public bool Enabled => _user.Enabled;

        public bool IsNew => _user.IsNew;

        public bool SSOOnly
        {
            get => _user.SSOOnly;
            set => _user.SSOOnly = value;
        }

        public bool SSODisconnectedFromOrg
        {
            get => _user.SSODisconnectedFromOrg;
            set => _user.SSODisconnectedFromOrg = value;
        }

        public ISession Session => (SessionWrapper) _user.Session;

        public event EventHandler<IPersistentObjectEventArgs> Committed;
        private void onCommitted(object source, PersistentObjectEventArgs e)
        {  
            try
            {      
                Committed?.Invoke(source, (PersistentObjectEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public void ChangeOrganization(Organization newOrganization) => _user.ChangeOrganization(newOrganization);

        public void Enable() => _user.Enable();

        public void Disable() => _user.Disable();

        public bool HasAccessTo(Feature feature) => _user.HasAccessTo(feature);

        public void GrantAccessTo(Feature feature) => _user.GrantAccessTo(feature);

        public void RevokeAccessTo(Feature feature) => _user.RevokeAccessTo(feature);

        public DataObject GetCustomDataObject(string fileName) => _user.GetCustomDataObject(fileName);

        public void SaveCustomDataObject(string fileName, DataObject dataObj) => _user.SaveCustomDataObject(fileName, dataObj);

        public void AppendToCustomDataObject(string fileName, DataObject dataObj) => _user.AppendToCustomDataObject(fileName, dataObj);

        public void DeleteCustomDataObject(string fileName) => _user.DeleteCustomDataObject(fileName);

        public void Commit() => _user.Commit();

        public void Delete() => _user.Delete();

        public void Refresh() => _user.Refresh();

        public UserGroupList GetUserGroups() => _user.GetUserGroups();

        public string ToString() => _user.ToString();

        public static implicit operator UserWrapper(User value) => new UserWrapper(value);
        public static implicit operator User(UserWrapper value) => value._user;
    }
}
