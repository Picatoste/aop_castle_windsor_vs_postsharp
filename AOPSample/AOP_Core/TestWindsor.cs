using AOP_Core;
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
                    TraceFile.Output += String.Format("{0}\n", sb);


                    invocation.Proceed();

                    TraceFile.Output += String.Format("Result of {0} is: {1}\n", sb, invocation.ReturnValue);
                }
                catch (Exception e)
                {
                    TraceFile.Output += e.Message;
                    throw;
                }
            }
        }
    }
}
