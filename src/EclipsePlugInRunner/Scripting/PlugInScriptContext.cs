using System.Collections.Generic;
using VMS.CA.Scripting;
using VMS.DV.PD.Scripting;

namespace EclipsePlugInRunner.Scripting
{
    internal class PlugInScriptContext
    {
        public PlugInScriptContext(
            User user,
            Patient patient,
            PDPlanSetup PDplanSetup,
            IEnumerable<PDPlanSetup> pdPlansetupsInScope
            )
        {
            User = user;
            Patient = patient;
            PlanSetup = PDplanSetup;
            PlanSetupsInScope = pdPlansetupsInScope;
        }

        public User User { get; set; }
        public Patient Patient { get; set; }
        public PDPlanSetup PlanSetup { get; set; }
        public IEnumerable<PDPlanSetup> PlanSetupsInScope { get; set; }
        //public IEnumerable<PlanSum> PlanSumsInScope { get; set; }
    }
}