using System;
using System.Collections.Generic;
using System.Linq;
using VMS.DV.PD.Scripting;
using VMS.CA.Scripting;

namespace EclipsePlugInRunner.Helpers
{
    internal static class EsapiExtensions
    {
        public static IEnumerable<Tuple<Course, PDPlanSetup>> GetPlanningItems(this Patient patient)
        {
            var planningItems = new List<Tuple<Course, PDPlanSetup>>();
            if(patient.PDPlanSetups != null)
            {
                foreach(var pdps in patient.PDPlanSetups)
                {
                    planningItems.Add(new Tuple<Course, PDPlanSetup>(pdps.PlanSetup.Course, pdps));
                }
            }
            //removed plansetups here. There is no need to get the PlanSetup directly. In fact, you cannot get the plansetup from the 
            //ScriptContext because you must navigate through the PDPlanSetup to get to the plansetup.
            /*
            if (patient.Courses != null)
            {
                foreach (var course in patient.Courses)
                {
                    if (course.PlanSetups != null)
                    {
                        planningItems.AddRange(course.PlanSetups
                            .Select(p => new Tuple<Course,PDPlanSetup, PlanSetup>(course,null, p)));
                    }
                }
            }*/

            return planningItems;
        }
    }
}
