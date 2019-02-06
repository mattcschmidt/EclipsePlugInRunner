using VMS.DV.PD.Scripting;
using VMS.CA.Scripting;
using System.Linq;
using System.Collections.Generic;

namespace EclipsePlugInRunner.TestScript
{
    public class MainViewModel
    {
        private readonly PDPlanSetup _planSetup;

        public MainViewModel(PDPlanSetup planSetup)
        {
            _planSetup = planSetup;
        }

        public string PlanSetupId
        {
            //test the script to get pass rates.
            get { return _planSetup != null ? GetPDAnalsysis(_planSetup): "(No active plan.)"; }
        }
        public string GetPDAnalsysis(PDPlanSetup pdps)
        {
            string output = "";
            IEnumerable<EvaluationTestDesc> tests = new List<EvaluationTestDesc>
            {
                new EvaluationTestDesc(EvaluationTestKind.GammaAreaLessThanOne,0,0.95,true)
            };
            PDTemplate template = new PDTemplate(false, false, false,
                AnalysisMode.CU, NormalizationMethod.Unknown,
                false, 0, ROIType.Field, 10, 0.03, 3, false, tests);
            foreach (PDBeam pdb in pdps.Beams)
            {
                if (pdb.PredictedDoseImage != null)
                {
                    PDAnalysis pda = pdb.PortalDoseImages.Last().CreateTransientAnalysis(template, pdb.PredictedDoseImage);
                    double gamma = pda.EvaluationTests.First().TestValue * 100;
                    //Console.WriteLine($"Gamma pass rate for {pdb.Id} = {gamma:F2}%");
                    output += string.Format("Gamma pass rate for field {0} = {1:F2}%\n",pdb.Id,gamma);
                }
            }
            return output;
        }
    }
}
