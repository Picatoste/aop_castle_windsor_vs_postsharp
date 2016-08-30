using AOP_Core;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AOP_PostSharp
{
    public class TestPostSharp
    {
        [Serializable]
        public class TraceAttribute : OnMethodBoundaryAspect
        {
            private StringBuilder sb { get; set; }

            public override void OnEntry(MethodExecutionArgs eventArgs)
            {
                sb = new StringBuilder(eventArgs.Instance.GetType().Name)
                    .Append(".")
                    .Append(eventArgs.Method.ToString())
                    .Append("(");
                for (int i = 0; i < eventArgs.Arguments.Count(); i++)
                {
                    if (i > 0)
                        sb.Append(", ");
                    sb.Append(eventArgs.Arguments[i]);
                }
                sb.Append(")");
                TraceFile.Output += (String.Format("{0}\n", sb));
            }

            public override void OnSuccess(MethodExecutionArgs args)
            {
                base.OnSuccess(args);
            }

            public override void OnExit(MethodExecutionArgs eventArgs)
            {
                TraceFile.Output += (String.Format("Result of {0} is: {1}\n", sb, eventArgs.ReturnValue));
            }

            public override void OnException(MethodExecutionArgs args)
            {
                TraceFile.Output += args.Exception.Message;
            }
        }  


        [Serializable]
        public class HandleExceptionAttribute : OnExceptionAspect
        {
            private Type _expectedException;
            private Type _wrapInException;
            private string _message;

            // Constructor that takes in variable parameters when the attribute is applied
            public HandleExceptionAttribute(Type expectedExceptionType, Type wrapInExceptionType,
                                             string message)
            {
                _expectedException = expectedExceptionType;
                _wrapInException = wrapInExceptionType;
                _message = message;
            }

            // This method checks to see if the exception that was thrown from the method the 
            // attribute was applied on matches the expected exception type we passed into the 
            // constructor of the attribute
            public override Type GetExceptionType(MethodBase targetMethod)
            {
                return _expectedException; 
            }

            // This method is called when we have guaranteed the exception type thrown matches the
            // expected exception type passed in the constructor.  It wraps the thrown exception 
            // into a new exception and adds the custom message that was passed into the constructor
            public override void OnException(MethodExecutionArgs args)
            {
                args.FlowBehavior = FlowBehavior.Continue;
                Exception newException = (Exception)Activator.CreateInstance(
                        _wrapInException, new object[] { _message, _expectedException });

                throw newException;
            }
        }

        //public class CacheAttribute : OnMethodBoundaryAspect
        //{
        //    public override void OnEntry(MethodExecutionArgs args)
        //    {
        //        string key = args.Method.Name + "_" + Cache.GenerateKey(args.Arguments);

        //        object value = Cache.Get(key);

        //        if (value == null)
        //        {
        //            args.MethodExecutionTag = key;
        //        }

        //        else
        //        {
        //            args.ReturnValue = value;

        //            args.FlowBehavior = FlowBehavior.Return;
        //        }
        //    }

        //    public override void OnSuccess(MethodExecutionArgs args)
        //    {
        //        string key = args.MethodExecutionTag.ToString();

        //        Cache.Add(key, args.ReturnValue);
        //    }
        //}
    }
}
