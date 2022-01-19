using System;
using System.Collections;
using EllieMae.Encompass.BusinessObjects.Users;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public class StateLicensesWrapper : IStateLicenses
    {
        private readonly StateLicenses _stateLicenses;

        public StateLicensesWrapper(StateLicenses value)
        {
            _stateLicenses = value; 


        }

        public IStateLicense this[string id] => (StateLicenseWrapper) _stateLicenses[id];

        public ISession Session => (SessionWrapper) _stateLicenses.Session;

        public IStateLicense Add(string state) => (StateLicenseWrapper) _stateLicenses.Add(state);

        public IStateLicense Add(string state, string licenseNo, DateTime issueDate, DateTime startDate, DateTime endDate, string licenseStatus, DateTime statusDate, bool approved, bool exempt, DateTime lastChecked) => (StateLicenseWrapper) _stateLicenses.Add(state, licenseNo, issueDate, startDate, endDate, licenseStatus, statusDate, approved, exempt, lastChecked);

        public void Remove(string state) => _stateLicenses.Remove(state);

        public void Clear() => _stateLicenses.Clear();

        public IEnumerator GetEnumerator() => _stateLicenses.GetEnumerator();

        public static implicit operator StateLicensesWrapper(StateLicenses value) => new StateLicensesWrapper(value);
        public static implicit operator StateLicenses(StateLicensesWrapper value) => value._stateLicenses;
    }
}
