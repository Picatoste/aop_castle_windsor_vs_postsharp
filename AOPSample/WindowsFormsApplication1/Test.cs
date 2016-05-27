﻿using System;
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
using Castle.Windsor;
using Castle.MicroKernel.Registration;


namespace AOPSampleWinForm
{
    public partial class TestForm : Form
    {

        string output {get; set;}

        public interface ISmsSender
        {
            int Send(string to, string msg);
        }



        [Interceptor("Trace")]
        public class SmsSender : ISmsSender
        {
            public int Send(string to, string msg)
            {
                if (msg.Length > 160)
                    throw new ArgumentException("too long", "msg");
                return to.Length;
            }
        }

        [HandleException(typeof(ArgumentException), typeof(ArgumentException), "msg Description")]
        [Trace]
        public class SmsSender2 
        {
            public int Send(string to, string msg)
            {
                if (msg.Length > 160)
                    throw new ArgumentException("too long", "msg");
                return to.Length;
            }
        }



        public TestForm()
        {
            InitializeComponent();
        }

        private void btnPostSharp_Click(object sender, EventArgs e)
        {

            txtOutput.AppendTextLine("POSTSHARP TEST");
            txtOutput.AppendTextLine("-------------------");
            SmsSender2 oSms = new SmsSender2();
            oSms.Send("Hola mundo", "Hola mundo");
            txtOutput.AppendTextLine("RESULT:");
            txtOutput.AppendTextLine(TestPostSharp.Output);
            txtOutput.AppendTextLine("-------------------");
            TestPostSharp.Output = "";

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
            txtOutput.AppendTextLine(TestWindsor.Output);
            txtOutput.AppendTextLine("-------------------");
            TestWindsor.Output = "";
        }

    }

}
