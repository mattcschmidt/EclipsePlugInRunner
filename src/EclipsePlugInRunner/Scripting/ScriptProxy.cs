using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using VMS.DV.PD.Scripting;
using VMS.CA.Scripting;
using System;

namespace EclipsePlugInRunner.Scripting
{
    internal class ScriptProxy
    {
        private readonly object _scriptInstance;
        private readonly MethodInfo _scriptRunMethod;

        public ScriptProxy(object scriptInstance)
        {
            _scriptInstance = scriptInstance;
            _scriptRunMethod = GetScriptRunMethod();
        }

        public void RunWithNewWindow(PlugInScriptContext scriptContext)
        {
            var scriptWindow = new Window();
            InvokeScriptRun(scriptContext, scriptWindow);
            scriptWindow.ShowDialog();
        }

        private MethodInfo GetScriptRunMethod()
        {
            return _scriptInstance.GetType().GetMethod("Run", new[]
            {
                typeof(User),
                typeof(Patient),
                typeof(PDPlanSetup),
                typeof(IEnumerable<PDPlanSetup>),
                typeof(Window)
            });
        }

        private void InvokeScriptRun(PlugInScriptContext scriptContext, Window scriptWindow)
        {
                _scriptRunMethod.Invoke(_scriptInstance, new object[]
                {
                scriptContext.User,
                scriptContext.Patient,
                scriptContext.PlanSetup,
                scriptContext.PlanSetupsInScope,
                scriptWindow
                });
        }

        private Exception Unwrap(TargetInvocationException root)
        {
            if (root.InnerException == null)
                return root;
            var innerException = root.InnerException as TargetInvocationException;
            if (innerException == null)
                return root.InnerException;

            return Unwrap(innerException);
        }
    }
}