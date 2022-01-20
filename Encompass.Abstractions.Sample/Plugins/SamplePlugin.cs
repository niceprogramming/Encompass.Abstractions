using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encompass.Abstractions.Automation;
using Encompass.Abstractions.BusinessObjects.Loans;

namespace Encompass.Abstractions.Sample.Plugins
{
    public class SamplePlugin : Plugin
    {
        public SamplePlugin(IEncompassApplication encompassApplication, IMacro macro) : base(encompassApplication, macro)
        {
        }


        public override void Activate()
        {
            // uses the abstraction from the parent class
            EncompassApplication.LoanOpened += LoanOpened;
            EncompassApplication.LoanClosing += LoanClosing;
            base.Activate();
        }

        private void LoanOpened(object sender, EventArgs e)
        {
            EncompassApplication.CurrentLoan.FieldChange += FieldChange;
        }

        private void FieldChange(object sender, IFieldChangeEventArgs e)
        {
            if (e.FieldID == "19" && e.NewValue.Contains("Refinance") && EncompassApplication.CurrentLoan.Fields["11"].IsEmpty())
            {
                Macro.Alert("You need a Subject Property Address");
            }

            //uw fees for nebraska should be 500
            if (e.FieldID == "14" && e.NewValue == "NE")
            {
                EncompassApplication.CurrentLoan.Fields["367"].Value = "500";
            }
        }

        private void LoanClosing(object sender, EventArgs e)
        {
            EncompassApplication.CurrentLoan.FieldChange -= FieldChange;
        }

        
        public override string DisplayName { get; }
    }
}
