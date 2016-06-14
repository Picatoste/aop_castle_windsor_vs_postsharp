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

       

        public TestForm()
        {
            InitializeComponent();
        }

        private void btnPostSharp_Click(object sender, EventArgs e)
        {

            txtOutput.AppendTextLine("POSTSHARP TEST");
            txtOutput.AppendTextLine("-------------------");
            SmsSenderPostSharp oSms = new SmsSenderPostSharp();
            oSms.Send("Hola mundo", "Hola mundo");
            txtOutput.AppendTextLine("RESULT:");
            txtOutput.AppendTextLine(TraceFile.Output);
            txtOutput.AppendTextLine("-------------------");
            TraceFile.Output = "";

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
                    _container.Register(Component.For<ISmsSender>().ImplementedBy<SmsSenderCastle>().LifestyleTransient());
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
            txtOutput.AppendTextLine(TraceFile.Output);
            txtOutput.AppendTextLine("-------------------");
            TraceFile.Output = "";
        }

    }

}
