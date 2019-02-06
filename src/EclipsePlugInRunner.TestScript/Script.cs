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
                //scriptContext.Image,
                //scriptContext.StructureSet, //no structure set available in portal dosimetry scripting
                //scriptContext.PlanSetup,
                scriptContext.PDPlanSetup,
                scriptContext.Patient.PDPlanSetups,
                //scriptContext.PlansInScope, // no plansums in portal dosimetry scripting
                mainWindow);
        }

        // This method must be present in any plug-in script that wants to use
        // EclipsePlugInRunner (it couldn't be named Execute because it confuses Eclipse)
        public void Run(
            User user,
            Patient patient,
            //DoseImage image,
            //StructureSet structureSet,
            PDPlanSetup pdPlanSetup,
            IEnumerable<PDPlanSetup> pdPlanSetupsInScope,
            //IEnumerable<PlanSum> planSumsInScope,
            Window mainWindow)
        {
            var mainViewModel = new MainViewModel(pdPlanSetup);
            var mainView = new MainView(mainViewModel);
            
            mainWindow.Content = mainView;
        }
    }
}
