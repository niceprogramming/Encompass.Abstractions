using System;
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Calendar;
using EllieMae.Encompass.BusinessObjects.Contacts;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.LockDeskSettings;
using EllieMae.Encompass.BusinessObjects.Settings;
using EllieMae.Encompass.BusinessObjects.TradeManagement;
using EllieMae.Encompass.BusinessObjects.Users;
using EllieMae.Encompass.Client;
using EllieMae.Encompass.Configuration;
using EllieMae.Encompass.Reporting;
using Encompass.Abstractions.BusinessObjects.Users;
using IUser = Encompass.Abstractions.BusinessObjects.Users.IUser;
using IUsers = Encompass.Abstractions.BusinessObjects.Users.IUsers;

namespace Encompass.Abstractions.Client
{
    public class SessionWrapper : ISession
    {
        private readonly Session _session;

        public SessionWrapper(Session value)
        {
            _session = value; 

           value.Disconnected += onDisconnected;
           value.MessageArrived += onMessageArrived;

        }

        public string UserID => _session.UserID;

        public string ClientID => _session.ClientID;

        public string SystemID => _session.SystemID;

        public string ServerID => _session.ServerID;

        public string ServerURI => _session.ServerURI;

        public string ID => _session.ID;

        public string ServerSessionID => _session.ServerSessionID;

        public string OAPIGatewayBaseUri => _session.OAPIGatewayBaseUri;

        public EncompassEdition EncompassEdition => _session.EncompassEdition;

        public Loans Loans => _session.Loans;

        public Calendar Calendar => _session.Calendar;

        public Contacts Contacts => _session.Contacts;

        public IUsers Users => (UsersWrapper) _session.Users;

        public Organizations Organizations => _session.Organizations;

        public ServerEvents ServerEvents => _session.ServerEvents;

        public DataExchange DataExchange => _session.DataExchange;

        public Reports Reports => _session.Reports;

        public SystemSettings SystemSettings => _session.SystemSettings;

        public CorrespondentMasterService CorrespondentMaster => _session.CorrespondentMaster;

        public bool IsConnected => _session.IsConnected;

        public CorrespondentTradeService CorrespondentTradeService => _session.CorrespondentTradeService;

        public GSECommitmentService GSECommitmentService => _session.GSECommitmentService;

        public LockDeskSettingsService LockDeskSettingsService => _session.LockDeskSettingsService;

        public LoanTradeService LoanTradeService => _session.LoanTradeService;

        public SecurityTradeService SecurityTradeService => _session.SecurityTradeService;

        public MbsPoolService MbsPoolService => _session.MbsPoolService;

        public MasterContractService MasterContractService => _session.MasterContractService;

        public TradeBatchService TradeBatchService => _session.TradeBatchService;

        public SettingsService SettingsService => _session.SettingsService;

        public string EncompassProgramDirectory => Session.EncompassProgramDirectory;

        public string EncompassDataDirectory => Session.EncompassDataDirectory;

        public string EpassDataDirectory => Session.EpassDataDirectory;

        public event EventHandler<IDisconnectedEventArgs> Disconnected;
        private void onDisconnected(object source, DisconnectedEventArgs e)
        {  
            try
            {      
                Disconnected?.Invoke(source, (DisconnectedEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<IServerMessageEventArgs> MessageArrived;
        private void onMessageArrived(object source, ServerMessageEventArgs e)
        {  
            try
            {      
                MessageArrived?.Invoke(source, (ServerMessageEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public void Start(string serverUri, string userId, string password) => _session.Start(serverUri, userId, password);

        public void StartOffline(string userId, string password) => _session.StartOffline(userId, password);

        public void StartInstance(string userId, string password, string instanceName) => _session.StartInstance(userId, password, instanceName);

        public void End() => _session.End();

        public string GetAuthToken() => _session.GetAuthToken();

        public DateTime GetServerTime() => _session.GetServerTime();

        public IUser GetCurrentUser() => (UserWrapper) _session.GetCurrentUser();

        public void ImpersonateUser(string userId) => _session.ImpersonateUser(userId);

        public void RestoreIdentity() => _session.RestoreIdentity();

        public static implicit operator SessionWrapper(Session value) => new SessionWrapper(value);
        public static implicit operator Session(SessionWrapper value) => value._session;
    }
}
