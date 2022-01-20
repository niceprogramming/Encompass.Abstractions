using System;
using Encompass.Abstractions.Automation;
using Encompass.Abstractions.BusinessObjects.Loans;
using Encompass.Abstractions.Sample.Plugins;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Encompass.Abstractions.Sample.Tests
{
    public class SamplePluginTests
    {
        private readonly ITestOutputHelper _output;

        public SamplePluginTests(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void FieldChanged_EmptyAddressForRefinance_ShowsAlert()
        {
            var alerted = false;
            //seems verbose but could probably just make a standard setup for tests.
            var encApp = new Mock<IEncompassApplication>();
            var macros = new Mock<IMacro>();
            var loan = new Mock<ILoan>();
            var fields = new Mock<ILoanFields>();

            macros.Setup(x => x.Alert(It.IsAny<string>())).Callback(() =>
            {
                alerted = true;
            });
            fields.SetupGet(x => x["11"]).Returns(new FakeLoanField("11", string.Empty));
            
            encApp.SetupGet(x => x.CurrentLoan).Returns(loan.Object);
            loan.SetupGet(x => x.Fields).Returns(fields.Object);

            var plugin = new SamplePlugin(encApp.Object, macros.Object);
            plugin.Activate();
            encApp.Raise(x => x.LoanOpened += null, this, EventArgs.Empty);

            loan.Raise(x => x.FieldChange += null, this, new FakeFieldChange("19", "Cash-Out Refinance"));

            Assert.True(alerted);
        }

        [Fact]
        public void FieldChanged_ZipcodeIsNebraska_SetsUnderwritingFee()
        {
            
            //seems verbose but could probably just make a standard setup for tests.
            var encApp = new Mock<IEncompassApplication>();
            var macros = new Mock<IMacro>();
            var loan = new Mock<ILoan>();
            var fields = new Mock<ILoanFields>(MockBehavior.Strict);

            var fee = String.Empty;
            fields.SetupGet(x => x["11"]).Returns(new FakeLoanField("11", "lmao"));
            fields.SetupSet(x => x["367"].Value = It.IsAny<string>()).Callback((object value) => fee = value.ToString() );

            encApp.SetupGet(x => x.CurrentLoan).Returns(loan.Object);
            loan.SetupGet(x => x.Fields).Returns(fields.Object);

            var plugin = new SamplePlugin(encApp.Object, macros.Object);
            plugin.Activate();
            encApp.Raise(x => x.LoanOpened += null, this, EventArgs.Empty);

            loan.Raise(x => x.FieldChange += null, this, new FakeFieldChange("14", "NE"));
            
            Assert.Matches(fee, "500");
        }
    }
}