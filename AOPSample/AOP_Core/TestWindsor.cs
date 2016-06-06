using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP_CastleWindsor
{
    public class TestWindsor
    {     
        public class Installers : IWindsorInstaller
        {
            public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
            {
                container
                .Register(Component.For<IInterceptor>().ImplementedBy<LoggingInterceptor>().Named("Trace"));
            }
        }

        public class LoggingInterceptor : IInterceptor
        {

            public static string Output { get; set; }

            public void Intercept(IInvocation invocation)
            {
                try
                {
                    StringBuilder sb = null;
                    sb = new StringBuilder(invocation.TargetType.Name)
                        .Append(".")
                        .Append(invocation.Method)
                        .Append("(");
                    for (int i = 0; i < invocation.Arguments.Length; i++)
                    {
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append(invocation.Arguments[i]);
                    }
                    sb.Append(")");
                    Output += String.Format("{0}\n", sb);
                    //FileRollerTrace.TraceMessage(System.Diagnostics.TraceEventType.Verbose, String.Format("{0}", sb), null);


                    invocation.Proceed();

                    Output += String.Format("Result of {0} is: {1}\n", sb, invocation.ReturnValue);
                    //FileRollerTrace.TraceMessage(System.Diagnostics.TraceEventType.Verbose, String.Format("Result of {0} is: {1}", sb, invocation.ReturnValue), null);
                }
                catch (Exception e)
                {
                    Output += e.Message;
                    //FileRollerTrace.TraceMessage(System.Diagnostics.TraceEventType.Error, e.Message, null);
                    throw;
                }
            }
        }
    }
}
