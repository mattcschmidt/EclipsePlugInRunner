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
            DoseImage doseImage,
            PDAnalysis analysis,
            PDBeam pdBeam,
            PDPlanSetup PDplanSetup,
            IEnumerable<PDPlanSetup> pdPlansetupsInScope
            )
        {
            User = user;
            Patient = patient;
            DoseImage = doseImage;
            PDAnalysis = analysis;
            PDBeam = pdBeam;
            PlanSetup = PDplanSetup;
            PlanSetupsInScope = pdPlansetupsInScope;
        }

        public User User { get; set; }
        public Patient Patient { get; set; }
        public DoseImage DoseImage { get; set; }
        public PDAnalysis PDAnalysis { get; set; }
        public PDBeam PDBeam { get; set; }
        public PDPlanSetup PlanSetup { get; set; }
        public IEnumerable<PDPlanSetup> PlanSetupsInScope { get; set; }
        //public IEnumerable<PlanSum> PlanSumsInScope { get; set; }
    }
}