using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Castle.Core;
using AOP_CastleWindsor;
using AOP_PostSharp;

using Trace = AOP_PostSharp.TestPostSharp.TraceAttribute;
using HandleException = AOP_PostSharp.TestPostSharp.HandleExceptionAttribute;
using LoggingInterceptor = AOP_CastleWindsor.TestWindsor.LoggingInterceptor;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using AOP_Core;


namespace AOPSampleWinForm
{
    public partial class TestForm : Form
    {

        string output {get; set;}

        //public interface ISmsSender
        //{
        //    int Send(string to, string msg);
        //}



        ////[Interceptor("Trace")]
        ////public class SmsSender : ISmsSender
        ////{
        ////    public int Send(string to, string msg)
        ////    {
        ////        if (msg.Length > 160)
        ////            throw new ArgumentException("too long", "msg");
        ////        return to.Length;
        ////    }
        ////}

        //[HandleException(typeof(ArgumentException), typeof(ArgumentException), "msg Description")]
        //[Trace]
        //public class SmsSender : ISmsSender
        //{
        //    public int Send(string to, string msg)
        //    {
        //        if (msg.Length > 160)
        //            throw new ArgumentException("too long", "msg");
        //        return to.Length;
        //    }
        //}



        public TestForm()
        {
            InitializeComponent();
        }

        private void btnPostSharp_Click(object sender, EventArgs e)
        {

            txtOutput.AppendTextLine("POSTSHARP TEST");
            txtOutput.AppendTextLine("-------------------");
            SmsSender oSms = new SmsSender();
            oSms.Send("Hola mundo", "Hola mundo");
            txtOutput.AppendTextLine("RESULT:");
            txtOutput.AppendTextLine(Trace.Output);
            txtOutput.AppendTextLine("-------------------");
            Trace.Output = "";

        }


        private WindsorContainer _container;
        private WindsorContainer container
        {
            get
            {
                if(_container == null)
                {
                    _container = new WindsorContainer();

                    //General registers - Interceptors
                    _container.Install(new AOP_CastleWindsor.TestWindsor.Installers());

                    //Concret registers
                    _container.Register(Component.For<ISmsSender>().ImplementedBy<SmsSender>().LifestyleTransient());
                }
                return _container;
            }
        }

        private void btnCastleWindsor_Click(object sender, EventArgs e)
        {
            txtOutput.AppendTextLine("CASTLE WINDSOR TEST");
            txtOutput.AppendTextLine("-------------------");
            ISmsSender oSms = container.Resolve<ISmsSender>();
            oSms.Send("Hola mundo", "Hola mundo");
            txtOutput.AppendTextLine("RESULT:");
            txtOutput.AppendTextLine(LoggingInterceptor.Output);
            txtOutput.AppendTextLine("-------------------");
            LoggingInterceptor.Output = "";
        }

    }

}
