using System;
using EllieMae.Encompass.Automation;

namespace Encompass.Abstractions.Automation
{
    public class MacroWrapper : IMacro
    {
        public MacroWrapper()
        {
                       
        }

        public void CopyField(string sourceFieldID, string targetFieldID) => Macro.CopyField(sourceFieldID, targetFieldID);

        public void OpenURL(string url, string parameters) => Macro.OpenURL(url, parameters);

        public void OpenURL(string url) => Macro.OpenURL(url);

        public void OpenEMail(string addressees, string subject) => Macro.OpenEMail(addressees, subject);

        public void OpenEMail(string addressees, string subject, string body) => Macro.OpenEMail(addressees, subject, body);

        public void Run(string fileName, string arguments, bool waitForExit) => Macro.Run(fileName, arguments, waitForExit);

        public void SendKeys(string keySequence) => Macro.SendKeys(keySequence);

        public void DisplayServices(string serviceType) => Macro.DisplayServices(serviceType);

        public bool Confirm(string message) => Macro.Confirm(message);

        public void Alert(string message) => Macro.Alert(message);

        public void ResolveZipCode(string expression, string cityFieldID, string countyFieldID, string stateFieldID) => Macro.ResolveZipCode(expression, cityFieldID, countyFieldID, stateFieldID);

        public void GoToScreen(EncompassScreen screen) => Macro.GoToScreen(screen);

        public void GoToForm(string formName) => Macro.GoToForm(formName);

        public void ExecAction(string action) => Macro.ExecAction(action);

        public void ExecSignature(string emnSignature) => Macro.ExecSignature(emnSignature);

        public string GetField(string fieldId) => Macro.GetField(fieldId);

        public void SetField(string fieldId, string value) => Macro.SetField(fieldId, value);

        public void SetFieldNoRules(string fieldId, string value) => Macro.SetFieldNoRules(fieldId, value);

        public void SetFieldEval(string fieldId, string expr) => Macro.SetFieldEval(fieldId, expr);

        public object Eval(string expr) => Macro.Eval(expr);

        public void Popup(string formName, string title, int width, int height) => Macro.Popup(formName, title, width, height);

        public void Print(string form1, string form2, string form3) => Macro.Print(form1, form2, form3);

        public void Print(string[] formNames) => Macro.Print(formNames);

        public void ApplyBusinessRule() => Macro.ApplyBusinessRule();

    }
}
