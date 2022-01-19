using System;
using System.Collections;
using EllieMae.Encompass.BusinessObjects.Users;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public interface IStateLicenses
    {    
        IStateLicense this[string id] { get; }

        ISession Session { get; }

        IStateLicense Add(string state);

        IStateLicense Add(string state, string licenseNo, DateTime issueDate, DateTime startDate, DateTime endDate, string licenseStatus, DateTime statusDate, bool approved, bool exempt, DateTime lastChecked);

        void Remove(string state);

        void Clear();

        IEnumerator GetEnumerator();

    }
}
