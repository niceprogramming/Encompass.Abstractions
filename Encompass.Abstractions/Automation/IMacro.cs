using System;
using EllieMae.Encompass.Automation;

namespace Encompass.Abstractions.Automation
{
    public interface IMacro
    {    
        void CopyField(string sourceFieldID, string targetFieldID);

        void OpenURL(string url, string parameters);

        void OpenURL(string url);

        void OpenEMail(string addressees, string subject);

        void OpenEMail(string addressees, string subject, string body);

        void Run(string fileName, string arguments, bool waitForExit);

        void SendKeys(string keySequence);

        void DisplayServices(string serviceType);

        bool Confirm(string message);

        void Alert(string message);

        void ResolveZipCode(string expression, string cityFieldID, string countyFieldID, string stateFieldID);

        void GoToScreen(EncompassScreen screen);

        void GoToForm(string formName);

        void ExecAction(string action);

        void ExecSignature(string emnSignature);

        string GetField(string fieldId);

        void SetField(string fieldId, string value);

        void SetFieldNoRules(string fieldId, string value);

        void SetFieldEval(string fieldId, string expr);

        object Eval(string expr);

        void Popup(string formName, string title, int width, int height);

        void Print(string form1, string form2, string form3);

        void Print(string[] formNames);

        void ApplyBusinessRule();

    }
}
