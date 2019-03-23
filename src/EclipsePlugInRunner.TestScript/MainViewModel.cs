﻿using VMS.DV.PD.Scripting;
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
            get { return _planSetup != null ? GetPDAnalsysis(_planSetup) : "(No active plan.)"; }
        }
        public string GetPDAnalsysis(PDPlanSetup pdps)
        {
            string output = "";
            //set up gamma evaluation at 95% pass rate.
            IEnumerable<EvaluationTestDesc> tests = new List<EvaluationTestDesc>
            {
                new EvaluationTestDesc(EvaluationTestKind.GammaAreaLessThanOne,0,0.95,true)
            };
            //set the portal dose template to 3%/3mm with a ROI of Field+1cm
            PDTemplate template = new PDTemplate(false, false, false,false,
                AnalysisMode.CU, NormalizationMethod.Unknown,
                false, 0, ROIType.Field, 10, 0.03, 3, false, tests);
            foreach (PDBeam pdb in pdps.Beams)
            {
                if (pdb.PredictedDoseImage != null)
                {
                    //get the portal dose analysis of the verification field.
                    //PDAnalysis pda = pdb.PortalDoseImages.Last().CreateTransientAnalysis(template, pdb.PredictedDoseImage);
                    //cannot create a new portal dose image in 15.5, instead just get the last portal dose analysis done.
                    PDAnalysis pdAnalysis = pdb.PortalDoseImages.Last().Analyses.OrderBy(x => x.CreationDate).LastOrDefault();
                    if (pdAnalysis == null)
                    {
                        output += string.Format("{0} has no analysis.", pdb.Id);
                    }
                    else
                    {
                        EvaluationTest gammaTest = pdAnalysis.EvaluationTests.FirstOrDefault(x => x.EvaluationTestKind == EvaluationTestKind.GammaAreaLessThanOne);
                        //double gamma = pda.EvaluationTests.First().TestValue * 100;
                        if (gammaTest == null)
                        {
                            output += string.Format("{0}: Gamma Area less than one not defined.", pdb.Id);
                        }
                        else
                        {
                            output += string.Format("Gamma pass rate for field {0} = {1:F2}%\n", pdb.Id, gammaTest.TestValue);
                        }
                    }
                }
            }
            return output;
        }
    }
}
