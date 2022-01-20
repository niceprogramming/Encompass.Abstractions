using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using EllieMae.Encompass.ComponentModel;
using Encompass.Abstractions.Automation;
using Encompass.Abstractions.Sample.Plugins;

namespace Encompass.Abstractions.Sample
{
    [Plugin]
    public class PluginHost
    {
        public PluginHost()
        {
            var container = new Container();

            container.Register<IEncompassApplication, EncompassApplicationWrapper>(Reuse.Singleton);
            container.Register<IMacro, MacroWrapper>(Reuse.Singleton);

            //could be any number of plugins
            container.Register<SamplePlugin>(Reuse.Singleton);

            var plugins = container.ResolveMany<Plugin>();

            foreach (var plugin in plugins)
            {
                plugin.Activate();
            }

        }
    }
}
