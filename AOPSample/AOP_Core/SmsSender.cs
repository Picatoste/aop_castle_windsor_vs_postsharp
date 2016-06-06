using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Trace = AOP_PostSharp.TestPostSharp.TraceAttribute;
using HandleException = AOP_PostSharp.TestPostSharp.HandleExceptionAttribute;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Core;


namespace AOP_Core
{

    public interface ISmsSender
    {
        int Send(string to, string msg);
    }

    [Interceptor("Trace")]
    [HandleException(typeof(ArgumentException), typeof(ArgumentException), "msg Description")]
    [Trace]
    public class SmsSender : ISmsSender
    {
        public int Send(string to, string msg)
        {
            if (msg.Length > 160)
                throw new ArgumentException("too long", "msg");
            return to.Length;
        }
    }
}
