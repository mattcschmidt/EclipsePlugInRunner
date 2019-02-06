using System.Windows;
using EclipsePlugInRunner.Scripting;
using VMS.DV.PD.Scripting;
using VMS.CA.Scripting;

namespace EclipsePlugInRunner.TestRunner
{
    public partial class App : System.Windows.Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Patient patient = null;  // Dummy reference to workaround ESAPI bug
            ScriptRunner.Run(new Script());
        }
    }
}
