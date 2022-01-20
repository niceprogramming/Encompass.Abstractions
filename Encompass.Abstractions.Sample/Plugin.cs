using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encompass.Abstractions.Automation;

namespace Encompass.Abstractions.Sample
{
    public abstract class Plugin
    {
        public IEncompassApplication EncompassApplication { get; }
        public IMacro Macro { get; }
        public bool Active { get; protected set; }
        public abstract string DisplayName { get; }

        protected Plugin(IEncompassApplication encompassApplication, IMacro macro)
        {
            EncompassApplication = encompassApplication;
            Macro = macro;
        }

        public virtual void Activate()
        {
            Active = true;
        }

        public virtual void Deactivate()
        {
            Active = false;
        }
    }
}
