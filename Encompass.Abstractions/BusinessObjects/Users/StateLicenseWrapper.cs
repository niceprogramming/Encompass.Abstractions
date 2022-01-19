using System;
using EllieMae.Encompass.BusinessObjects.Users;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public class StateLicenseWrapper : IStateLicense
    {
        private readonly StateLicense _stateLicense;

        public StateLicenseWrapper(StateLicense value)
        {
            _stateLicense = value; 


        }

        public string State => _stateLicense.State;

        public string LicenseNumber
        {
            get => _stateLicense.LicenseNumber;
            set => _stateLicense.LicenseNumber = value;
        }

        public object ExpirationDate
        {
            get => _stateLicense.ExpirationDate;
            set => _stateLicense.ExpirationDate = value;
        }

        public bool Enabled
        {
            get => _stateLicense.Enabled;
            set => _stateLicense.Enabled = value;
        }

        public bool Selected
        {
            get => _stateLicense.Selected;
            set => _stateLicense.Selected = value;
        }

        public bool Exempt
        {
            get => _stateLicense.Exempt;
            set => _stateLicense.Exempt = value;
        }

        public object IssueDate
        {
            get => _stateLicense.IssueDate;
            set => _stateLicense.IssueDate = value;
        }

        public object StartDate
        {
            get => _stateLicense.StartDate;
            set => _stateLicense.StartDate = value;
        }

        public string LicenseStatus
        {
            get => _stateLicense.LicenseStatus;
            set => _stateLicense.LicenseStatus = value;
        }

        public object StatusDate
        {
            get => _stateLicense.StatusDate;
            set => _stateLicense.StatusDate = value;
        }

        public object LastChecked
        {
            get => _stateLicense.LastChecked;
            set => _stateLicense.LastChecked = value;
        }

        public static implicit operator StateLicenseWrapper(StateLicense value) => new StateLicenseWrapper(value);
        public static implicit operator StateLicense(StateLicenseWrapper value) => value._stateLicense;
    }
}
