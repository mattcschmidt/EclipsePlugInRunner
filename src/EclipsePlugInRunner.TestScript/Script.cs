using System.Collections.Generic;
using System.Windows;
using EclipsePlugInRunner.TestScript;
using VMS.CA.Scripting;

namespace VMS.DV.PD.Scripting
{
    public class Script
    {
        public void Execute(ScriptContext scriptContext, Window mainWindow)
        {
            Run(scriptContext.CurrentUser,
                scriptContext.Patient,
                scriptContext.DoseImage,
                scriptContext.Analysis,
                scriptContext.PDBeam,
                scriptContext.PDPlanSetup,
                scriptContext.Patient.PDPlanSetups,
                mainWindow);
        }

        // This method must be present in any plug-in script that wants to use
        // PDPlugInRunner (it couldn't be named Execute because it confuses Eclipse)
        public void Run(
            User user,
            Patient patient,
            DoseImage doseImage,
            PDAnalysis analysis,
            PDBeam pdBeam,
            PDPlanSetup pdPlanSetup,
            IEnumerable<PDPlanSetup> pdPlanSetupsInScope,
            Window mainWindow)
        {
            var mainViewModel = new MainViewModel(pdPlanSetup);
            var mainView = new MainView(mainViewModel);

            mainWindow.Content = mainView;
        }
    }
}
