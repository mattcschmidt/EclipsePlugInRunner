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
            //Image image,
            //StructureSet structureSet,
            PDPlanSetup planSetup,
            IEnumerable<PDPlanSetup> pdPlansetupsInScope
            //IEnumerable<PlanSetup> planSetupsInScope,
            //IEnumerable<PlanSum> planSumsInScope)
            )
        {
            User = user;
            Patient = patient;
            //Image = image;
            //StructureSet = structureSet;
            PlanSetup = planSetup;
            PlanSetupsInScope = pdPlansetupsInScope;
            //PlanSumsInScope = planSumsInScope;
        }

        public User User { get; set; }
        public Patient Patient { get; set; }
        public Image Image { get; set; }
        public StructureSet StructureSet { get; set; }
        public PDPlanSetup PlanSetup { get; set; }
        public IEnumerable<PDPlanSetup> PlanSetupsInScope { get; set; }
        //public IEnumerable<PlanSum> PlanSumsInScope { get; set; }
    }
}