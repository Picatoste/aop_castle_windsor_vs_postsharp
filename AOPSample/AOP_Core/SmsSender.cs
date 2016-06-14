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

    //[HandleException(typeof(ArgumentException), typeof(ArgumentException), "msg Description")]

    [Interceptor("Trace")]    
    public class SmsSenderCastle : ISmsSender
    {
        public int Send(string to, string msg)
        {
            if (msg.Length > 160)
                throw new ArgumentException("too long", "msg");
            return to.Length;
        }
    }

    [Trace]
    public class SmsSenderPostSharp : ISmsSender
    {
        public int Send(string to, string msg)
        {
            if (msg.Length > 160)
                throw new ArgumentException("too long", "msg");
            return to.Length;
        }
    }

    public class SmsSenderWithoutAOP : ISmsSender
    {

        public int Send(string to, string msg)
        {
            try
            {
                StringBuilder sb = new StringBuilder("SmsSender.Send(to, msg)");
                TraceFile.Output += (String.Format("{0}\n", sb));

                if (msg.Length > 160)
                    throw new ArgumentException("too long", "msg");

                TraceFile.Output += (String.Format("Result of {0} is: {1}\n", sb, to.Length));
                return to.Length;

            }
            catch (ArgumentException ex)
            {
                TraceFile.Output += ex.Message;
                throw new ArgumentException("error!", ex.Message);
            }
        }
    }

}
