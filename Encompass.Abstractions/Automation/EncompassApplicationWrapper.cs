using System;
using EllieMae.Encompass.Automation;
using Encompass.Abstractions.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;

namespace Encompass.Abstractions.Automation
{
    public class EncompassApplicationWrapper : IEncompassApplication
    {
        public EncompassApplicationWrapper()
        {
           EncompassApplication.Login += onLogin;
           EncompassApplication.Logout += onLogout;
           EncompassApplication.LoanOpened += onLoanOpened;
           EncompassApplication.LoanClosing += onLoanClosing;
                       
        }

        public string[] CommandLineArguments => EncompassApplication.CommandLineArguments;

        public ApplicationScreens Screens => EncompassApplication.Screens;

        public ISession Session => (SessionWrapper) EncompassApplication.Session;

        public ILoan CurrentLoan => (LoanWrapper) EncompassApplication.CurrentLoan;

        public IUser CurrentUser => (UserWrapper) EncompassApplication.CurrentUser;

        public EPass EPass => EncompassApplication.EPass;

        public LoanServices LoanServices => EncompassApplication.LoanServices;

        public event EventHandler<EventArgs> Login;
        private void onLogin(object source, EventArgs e)
        {  
            try
            {      
                Login?.Invoke(source, (EventArgs) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<EventArgs> Logout;
        private void onLogout(object source, EventArgs e)
        {  
            try
            {      
                Logout?.Invoke(source, (EventArgs) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<EventArgs> LoanOpened;
        private void onLoanOpened(object source, EventArgs e)
        {  
            try
            {      
                LoanOpened?.Invoke(source, (EventArgs) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<EventArgs> LoanClosing;
        private void onLoanClosing(object source, EventArgs e)
        {  
            try
            {      
                LoanClosing?.Invoke(source, (EventArgs) e);
            }
            catch(Exception exception)
            {
            }
        }

        public void Attach() => EncompassApplication.Attach();

    }
}
