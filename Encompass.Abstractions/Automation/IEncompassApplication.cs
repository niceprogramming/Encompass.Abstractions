using System;
using EllieMae.Encompass.Automation;
using Encompass.Abstractions.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;

namespace Encompass.Abstractions.Automation
{
    public interface IEncompassApplication
    {    
        string[] CommandLineArguments { get; }

        ApplicationScreens Screens { get; }

        ISession Session { get; }

        ILoan CurrentLoan { get; }

        IUser CurrentUser { get; }

        EPass EPass { get; }

        LoanServices LoanServices { get; }

        event EventHandler<EventArgs> Login;

        event EventHandler<EventArgs> Logout;

        event EventHandler<EventArgs> LoanOpened;

        event EventHandler<EventArgs> LoanClosing;

        void Attach();

    }
}
