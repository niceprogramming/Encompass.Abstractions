using System;
using System.Collections.Generic;
using EllieMae.Encompass.BusinessEnums;
using EllieMae.Encompass.BusinessObjects;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using EllieMae.Encompass.BusinessObjects.Loans.Servicing;
using EllieMae.Encompass.BusinessObjects.Loans.Templates;
using EllieMae.Encompass.Collections;
using Encompass.Abstractions.BusinessObjects.Loans;
using Encompass.Abstractions.BusinessObjects.Users;
using Encompass.Abstractions.Client;
using ILoanFields = Encompass.Abstractions.BusinessObjects.Loans.ILoanFields;

namespace Encompass.Abstractions.BusinessObjects.Loans
{
    public class LoanWrapper : ILoan
    {
        private readonly Loan _loan;

        public LoanWrapper(Loan value)
        {
            _loan = value; 

           value.BeforeCommit += onBeforeCommit;
           value.Committed += onCommitted;
           value.FieldChange += onFieldChange;
           value.OnLoanRefreshedFromServer += onOnLoanRefreshedFromServer;
           value.LogEntryAdded += onLogEntryAdded;
           value.LogEntryRemoved += onLogEntryRemoved;
           value.BeforeExtensionInvoked += onBeforeExtensionInvoked;
           value.AfterExtensionInvoked += onAfterExtensionInvoked;
           value.LogEntryChange += onLogEntryChange;
           value.BeforeMilestoneCompleted += onBeforeMilestoneCompleted;
           value.MilestoneCompleted += onMilestoneCompleted;

        }

        public string LoanFolder
        {
            get => _loan.LoanFolder;
            set => _loan.LoanFolder = value;
        }

        public string LoanName
        {
            get => _loan.LoanName;
            set => _loan.LoanName = value;
        }

        public string Guid => _loan.Guid;

        public string LoanNumber
        {
            get => _loan.LoanNumber;
            set => _loan.LoanNumber = value;
        }

        public int LoanVersionNumber => _loan.LoanVersionNumber;

        public string EncompassVersion
        {
            get => _loan.EncompassVersion;
            set => _loan.EncompassVersion = value;
        }

        public string MersNumber
        {
            get => _loan.MersNumber;
            set => _loan.MersNumber = value;
        }

        public bool CalculationsEnabled
        {
            get => _loan.CalculationsEnabled;
            set => _loan.CalculationsEnabled = value;
        }

        public bool BusinessRulesEnabled
        {
            get => _loan.BusinessRulesEnabled;
            set => _loan.BusinessRulesEnabled = value;
        }

        public bool LoanAccessExceptionsEnabled
        {
            get => _loan.LoanAccessExceptionsEnabled;
            set => _loan.LoanAccessExceptionsEnabled = value;
        }

        public DateTime LastModified => _loan.LastModified;

        public string LoanOfficerID => _loan.LoanOfficerID;

        public string LoanProcessorID => _loan.LoanProcessorID;

        public string LoanCloserID => _loan.LoanCloserID;

        public ILoanFields Fields => (LoanFieldsWrapper) _loan.Fields;

        public LoanBorrowerPairs BorrowerPairs => _loan.BorrowerPairs;

        public LoanLiabilities Liabilities => _loan.Liabilities;

        public LoanMortgages Mortgages => _loan.Mortgages;

        public LoanDeposits Deposits => _loan.Deposits;

        public LoanResidences BorrowerResidences => _loan.BorrowerResidences;

        public LoanResidences CoBorrowerResidences => _loan.CoBorrowerResidences;

        public LoanEmployers BorrowerEmployers => _loan.BorrowerEmployers;

        public LoanEmployers CoBorrowerEmployers => _loan.CoBorrowerEmployers;

        public LoanVestingParties AdditionalVestingParties => _loan.AdditionalVestingParties;

        public NonBorrowingOwnerContacts NBOContacts => _loan.NBOContacts;

        public ChangeOfCircumstanceEntries CoCEntries => _loan.CoCEntries;

        public LoanLog Log => _loan.Log;

        public MilestoneTemplate MilestoneTemplate => _loan.MilestoneTemplate;

        public LoanAttachments Attachments => _loan.Attachments;

        public LoanAssociates Associates => _loan.Associates;

        public LoanContacts Contacts => _loan.Contacts;

        public LoanAuditTrail AuditTrail => _loan.AuditTrail;

        public LoanServicing Servicing => _loan.Servicing;

        public LoanURLAAdditionalLoans URLAAdditionalLoans => _loan.URLAAdditionalLoans;

        public LoanURLAGiftsGrants URLAGiftsGrants => _loan.URLAGiftsGrants;

        public LoanURLAOtherAssets URLAOtherAssets => _loan.URLAOtherAssets;

        public LoanURLAOtherIncome URLAOtherIncome => _loan.URLAOtherIncome;

        public LoanURLAOtherLiabilities URLAOtherLiabilities => _loan.URLAOtherLiabilities;

        public ILoan LinkedLoan => (LoanWrapper) _loan.LinkedLoan;

        public bool MSLock
        {
            get => _loan.MSLock;
            set => _loan.MSLock = value;
        }

        public bool MSDateLock
        {
            get => _loan.MSDateLock;
            set => _loan.MSDateLock = value;
        }

        public bool Locked => _loan.Locked;

        public bool LockedExclusive => _loan.LockedExclusive;

        public bool IsNew => _loan.IsNew;

        public bool Modified => _loan.Modified;

        public ISession Session => (SessionWrapper) _loan.Session;

        public event EventHandler<ICancelableEventArgs> BeforeCommit;
        private void onBeforeCommit(object source, CancelableEventArgs e)
        {  
            try
            {      
                BeforeCommit?.Invoke(source, (CancelableEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

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

        public event EventHandler<IFieldChangeEventArgs> FieldChange;
        private void onFieldChange(object source, FieldChangeEventArgs e)
        {  
            try
            {      
                FieldChange?.Invoke(source, (FieldChangeEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<EventArgs> OnLoanRefreshedFromServer;
        private void onOnLoanRefreshedFromServer(object source, EventArgs e)
        {  
            try
            {      
                OnLoanRefreshedFromServer?.Invoke(source, (EventArgs) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<ILogEntryEventArgs> LogEntryAdded;
        private void onLogEntryAdded(object source, LogEntryEventArgs e)
        {  
            try
            {      
                LogEntryAdded?.Invoke(source, (LogEntryEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<ILogEntryEventArgs> LogEntryRemoved;
        private void onLogEntryRemoved(object source, LogEntryEventArgs e)
        {  
            try
            {      
                LogEntryRemoved?.Invoke(source, (LogEntryEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<IExtensionInvocationEventArgs> BeforeExtensionInvoked;
        private void onBeforeExtensionInvoked(object source, ExtensionInvocationEventArgs e)
        {  
            try
            {      
                BeforeExtensionInvoked?.Invoke(source, (ExtensionInvocationEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<IExtensionInvocationEventArgs> AfterExtensionInvoked;
        private void onAfterExtensionInvoked(object source, ExtensionInvocationEventArgs e)
        {  
            try
            {      
                AfterExtensionInvoked?.Invoke(source, (ExtensionInvocationEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<ILogEntryEventArgs> LogEntryChange;
        private void onLogEntryChange(object source, LogEntryEventArgs e)
        {  
            try
            {      
                LogEntryChange?.Invoke(source, (LogEntryEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<ICancelableMilestoneEventArgs> BeforeMilestoneCompleted;
        private void onBeforeMilestoneCompleted(object source, CancelableMilestoneEventArgs e)
        {  
            try
            {      
                BeforeMilestoneCompleted?.Invoke(source, (CancelableMilestoneEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public event EventHandler<IMilestoneEventArgs> MilestoneCompleted;
        private void onMilestoneCompleted(object source, MilestoneEventArgs e)
        {  
            try
            {      
                MilestoneCompleted?.Invoke(source, (MilestoneEventArgsWrapper) e);
            }
            catch(Exception exception)
            {
            }
        }

        public void ApplyInvestorToLoan(InvestorTemplate investorTemplate) => _loan.ApplyInvestorToLoan(investorTemplate);

        public void ApplyManualMilestoneTemplate(MilestoneTemplate milestoneTemplate, bool forceApplyMilestoneTemplate) => _loan.ApplyManualMilestoneTemplate(milestoneTemplate, forceApplyMilestoneTemplate);

        public void ApplyBestMatchingMilestoneTemplate(bool forceApplyMilestoneTemplate) => _loan.ApplyBestMatchingMilestoneTemplate(forceApplyMilestoneTemplate);

        public void LinkTo(ILoan loan) => _loan.LinkTo((LoanWrapper) loan);

        public void Unlink() => _loan.Unlink();

        public void SendToLoanOfficer(IUser loanOfficer) => _loan.SendToLoanOfficer((UserWrapper) loanOfficer);

        public void SendToProcessing(IUser loanProcessor) => _loan.SendToProcessing((UserWrapper) loanProcessor);

        public void Lock() => _loan.Lock();

        public void Lock(bool exclusive) => _loan.Lock(exclusive);

        public void Unlock() => _loan.Unlock();

        public LoanLock GetCurrentLock() => _loan.GetCurrentLock();

        public LoanLockList GetCurrentLocks() => _loan.GetCurrentLocks();

        public void ForceLock() => _loan.ForceLock();

        public void ForceUnlock() => _loan.ForceUnlock();

        public void Recalculate() => _loan.Recalculate();

        public void ExecuteCalculation(string calcName) => _loan.ExecuteCalculation(calcName);

        public void ExecuteCalculation(CalculationTriggerOptions triggerOption) => _loan.ExecuteCalculation(triggerOption);

        public void Export(string filePath, string exportKey, LoanExportFormat format) => _loan.Export(filePath, exportKey, format);

        public string ExportAsText(string exportKey, LoanExportFormat format) => _loan.ExportAsText(exportKey, format);

        public string ExportAsText(string exportKey, LoanExportFormat format, bool currentBorPairOnly) => _loan.ExportAsText(exportKey, format, currentBorPairOnly);

        public void Import(string filePath, LoanImportFormat format) => _loan.Import(filePath, format);

        public void ImportWithTemplate(string filePath, LoanImportFormat format, LoanTemplate template) => _loan.ImportWithTemplate(filePath, format, template);

        public void ImportWithLoanOfficer(string filePath, LoanImportFormat format, LoanTemplate template, IUser user) => _loan.ImportWithLoanOfficer(filePath, format, template, (UserWrapper) user);

        public void ImportFromBytes(ref Byte[] importData, LoanImportFormat format) => _loan.ImportFromBytes(ref importData, format);

        public void Commit() => _loan.Commit();

        public void Refresh() => _loan.Refresh();

        public void Close() => _loan.Close();

        public void Move(LoanFolder newFolder, string newLoanName) => _loan.Move(newFolder, newLoanName);

        public void MoveToFolder(LoanFolder newFolder) => _loan.MoveToFolder(newFolder);

        public void Delete() => _loan.Delete();

        public DataObject GetCustomDataObject(string name) => _loan.GetCustomDataObject(name);

        public void SaveCustomDataObject(string name, DataObject data) => _loan.SaveCustomDataObject(name, data);

        public void AppendToCustomDataObject(string name, DataObject data) => _loan.AppendToCustomDataObject(name, data);

        public void DeleteCustomDataObject(string name) => _loan.DeleteCustomDataObject(name);

        public DataObject GetEPassTransactionDataObject(string name) => _loan.GetEPassTransactionDataObject(name);

        public void SaveEPassTransactionDataObject(string name, DataObject data) => _loan.SaveEPassTransactionDataObject(name, data);

        public LoanAccessRights GetAccessRights() => _loan.GetAccessRights();

        public LoanAccessRights GetAssignedAccessRights(IUser user) => _loan.GetAssignedAccessRights((UserWrapper) user);

        public LoanAccessRights GetEffectiveAccessRights(IUser user) => _loan.GetEffectiveAccessRights((UserWrapper) user);

        public UserList GetUsersWithAssignedRights() => _loan.GetUsersWithAssignedRights();

        public void AssignRights(IUser user, LoanAccessRights rights) => _loan.AssignRights((UserWrapper) user, rights);

        public void ApplyTemplate(Template tmpl, bool appendData) => _loan.ApplyTemplate(tmpl, appendData);

        public void SetClosingDocumentFieldOverride(string fieldId, bool ovrrde) => _loan.SetClosingDocumentFieldOverride(fieldId, ovrrde);

        public bool IsClosingDocumentFieldOverridden(string fieldId) => _loan.IsClosingDocumentFieldOverridden(fieldId);

        public FundingFeeList GetFundingFees(bool hideZero) => _loan.GetFundingFees(hideZero);

        public IList<Type> GetOnBeforeCommitExtensions() => _loan.GetOnBeforeCommitExtensions();

        public IList<Type> GetOnCommittedExtensions() => _loan.GetOnCommittedExtensions();

        public bool ValidateUnderwritingAdvancedConditions(string contactID) => _loan.ValidateUnderwritingAdvancedConditions(contactID);

        public string GetUCDForLoanEstimate(bool setTotalFields) => _loan.GetUCDForLoanEstimate(setTotalFields);

        public string GetUCDForClosingDisclosure(bool setTotalFields) => _loan.GetUCDForClosingDisclosure(setTotalFields);

        public static implicit operator LoanWrapper(Loan value) => new LoanWrapper(value);
        public static implicit operator Loan(LoanWrapper value) => value._loan;
    }
}
