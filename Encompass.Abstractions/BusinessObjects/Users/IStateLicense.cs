using System;
using EllieMae.Encompass.BusinessObjects.Users;

namespace Encompass.Abstractions.BusinessObjects.Users
{
    public interface IStateLicense
    {    
        string State { get; }

        string LicenseNumber { get; set; }

        object ExpirationDate { get; set; }

        bool Enabled { get; set; }

        bool Selected { get; set; }

        bool Exempt { get; set; }

        object IssueDate { get; set; }

        object StartDate { get; set; }

        string LicenseStatus { get; set; }

        object StatusDate { get; set; }

        object LastChecked { get; set; }

    }
}
