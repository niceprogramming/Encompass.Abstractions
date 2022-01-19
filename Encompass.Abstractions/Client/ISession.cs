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
    public interface ISession
    {    
        string UserID { get; }

        string ClientID { get; }

        string SystemID { get; }

        string ServerID { get; }

        string ServerURI { get; }

        string ID { get; }

        string ServerSessionID { get; }

        string OAPIGatewayBaseUri { get; }

        EncompassEdition EncompassEdition { get; }

        Loans Loans { get; }

        Calendar Calendar { get; }

        Contacts Contacts { get; }

        IUsers Users { get; }

        Organizations Organizations { get; }

        ServerEvents ServerEvents { get; }

        DataExchange DataExchange { get; }

        Reports Reports { get; }

        SystemSettings SystemSettings { get; }

        CorrespondentMasterService CorrespondentMaster { get; }

        bool IsConnected { get; }

        CorrespondentTradeService CorrespondentTradeService { get; }

        GSECommitmentService GSECommitmentService { get; }

        LockDeskSettingsService LockDeskSettingsService { get; }

        LoanTradeService LoanTradeService { get; }

        SecurityTradeService SecurityTradeService { get; }

        MbsPoolService MbsPoolService { get; }

        MasterContractService MasterContractService { get; }

        TradeBatchService TradeBatchService { get; }

        SettingsService SettingsService { get; }

        string EncompassProgramDirectory { get; }

        string EncompassDataDirectory { get; }

        string EpassDataDirectory { get; }

        event EventHandler<IDisconnectedEventArgs> Disconnected;

        event EventHandler<IServerMessageEventArgs> MessageArrived;

        void Start(string serverUri, string userId, string password);

        void StartOffline(string userId, string password);

        void StartInstance(string userId, string password, string instanceName);

        void End();

        string GetAuthToken();

        DateTime GetServerTime();

        IUser GetCurrentUser();

        void ImpersonateUser(string userId);

        void RestoreIdentity();

    }
}
