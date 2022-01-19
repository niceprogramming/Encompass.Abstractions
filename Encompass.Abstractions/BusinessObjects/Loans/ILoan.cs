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
    public interface ILoan
    {    
        string LoanFolder { get; set; }

        string LoanName { get; set; }

        string Guid { get; }

        string LoanNumber { get; set; }

        int LoanVersionNumber { get; }

        string EncompassVersion { get; set; }

        string MersNumber { get; set; }

        bool CalculationsEnabled { get; set; }

        bool BusinessRulesEnabled { get; set; }

        bool LoanAccessExceptionsEnabled { get; set; }

        DateTime LastModified { get; }

        string LoanOfficerID { get; }

        string LoanProcessorID { get; }

        string LoanCloserID { get; }

        ILoanFields Fields { get; }

        LoanBorrowerPairs BorrowerPairs { get; }

        LoanLiabilities Liabilities { get; }

        LoanMortgages Mortgages { get; }

        LoanDeposits Deposits { get; }

        LoanResidences BorrowerResidences { get; }

        LoanResidences CoBorrowerResidences { get; }

        LoanEmployers BorrowerEmployers { get; }

        LoanEmployers CoBorrowerEmployers { get; }

        LoanVestingParties AdditionalVestingParties { get; }

        NonBorrowingOwnerContacts NBOContacts { get; }

        ChangeOfCircumstanceEntries CoCEntries { get; }

        LoanLog Log { get; }

        MilestoneTemplate MilestoneTemplate { get; }

        LoanAttachments Attachments { get; }

        LoanAssociates Associates { get; }

        LoanContacts Contacts { get; }

        LoanAuditTrail AuditTrail { get; }

        LoanServicing Servicing { get; }

        LoanURLAAdditionalLoans URLAAdditionalLoans { get; }

        LoanURLAGiftsGrants URLAGiftsGrants { get; }

        LoanURLAOtherAssets URLAOtherAssets { get; }

        LoanURLAOtherIncome URLAOtherIncome { get; }

        LoanURLAOtherLiabilities URLAOtherLiabilities { get; }

        ILoan LinkedLoan { get; }

        bool MSLock { get; set; }

        bool MSDateLock { get; set; }

        bool Locked { get; }

        bool LockedExclusive { get; }

        bool IsNew { get; }

        bool Modified { get; }

        ISession Session { get; }

        event EventHandler<ICancelableEventArgs> BeforeCommit;

        event EventHandler<IPersistentObjectEventArgs> Committed;

        event EventHandler<IFieldChangeEventArgs> FieldChange;

        event EventHandler<EventArgs> OnLoanRefreshedFromServer;

        event EventHandler<ILogEntryEventArgs> LogEntryAdded;

        event EventHandler<ILogEntryEventArgs> LogEntryRemoved;

        event EventHandler<IExtensionInvocationEventArgs> BeforeExtensionInvoked;

        event EventHandler<IExtensionInvocationEventArgs> AfterExtensionInvoked;

        event EventHandler<ILogEntryEventArgs> LogEntryChange;

        event EventHandler<ICancelableMilestoneEventArgs> BeforeMilestoneCompleted;

        event EventHandler<IMilestoneEventArgs> MilestoneCompleted;

        void ApplyInvestorToLoan(InvestorTemplate investorTemplate);

        void ApplyManualMilestoneTemplate(MilestoneTemplate milestoneTemplate, bool forceApplyMilestoneTemplate);

        void ApplyBestMatchingMilestoneTemplate(bool forceApplyMilestoneTemplate);

        void LinkTo(ILoan loan);

        void Unlink();

        void SendToLoanOfficer(IUser loanOfficer);

        void SendToProcessing(IUser loanProcessor);

        void Lock();

        void Lock(bool exclusive);

        void Unlock();

        LoanLock GetCurrentLock();

        LoanLockList GetCurrentLocks();

        void ForceLock();

        void ForceUnlock();

        void Recalculate();

        void ExecuteCalculation(string calcName);

        void ExecuteCalculation(CalculationTriggerOptions triggerOption);

        void Export(string filePath, string exportKey, LoanExportFormat format);

        string ExportAsText(string exportKey, LoanExportFormat format);

        string ExportAsText(string exportKey, LoanExportFormat format, bool currentBorPairOnly);

        void Import(string filePath, LoanImportFormat format);

        void ImportWithTemplate(string filePath, LoanImportFormat format, LoanTemplate template);

        void ImportWithLoanOfficer(string filePath, LoanImportFormat format, LoanTemplate template, IUser user);

        void ImportFromBytes(ref Byte[] importData, LoanImportFormat format);

        void Commit();

        void Refresh();

        void Close();

        void Move(LoanFolder newFolder, string newLoanName);

        void MoveToFolder(LoanFolder newFolder);

        void Delete();

        DataObject GetCustomDataObject(string name);

        void SaveCustomDataObject(string name, DataObject data);

        void AppendToCustomDataObject(string name, DataObject data);

        void DeleteCustomDataObject(string name);

        DataObject GetEPassTransactionDataObject(string name);

        void SaveEPassTransactionDataObject(string name, DataObject data);

        LoanAccessRights GetAccessRights();

        LoanAccessRights GetAssignedAccessRights(IUser user);

        LoanAccessRights GetEffectiveAccessRights(IUser user);

        UserList GetUsersWithAssignedRights();

        void AssignRights(IUser user, LoanAccessRights rights);

        void ApplyTemplate(Template tmpl, bool appendData);

        void SetClosingDocumentFieldOverride(string fieldId, bool ovrrde);

        bool IsClosingDocumentFieldOverridden(string fieldId);

        FundingFeeList GetFundingFees(bool hideZero);

        IList<Type> GetOnBeforeCommitExtensions();

        IList<Type> GetOnCommittedExtensions();

        bool ValidateUnderwritingAdvancedConditions(string contactID);

        string GetUCDForLoanEstimate(bool setTotalFields);

        string GetUCDForClosingDisclosure(bool setTotalFields);

    }
}
