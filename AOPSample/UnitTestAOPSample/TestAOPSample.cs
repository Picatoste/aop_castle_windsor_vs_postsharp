using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using AOP_Core;

namespace UnitTestAOPSample
{
    [TestClass]
    public class TestAOPSample
    {

        #region "CastleWindsor"

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0001()
        {
            Loop_CastleWindsor(1);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0002()
        {
            Loop_CastleWindsor(2);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0003()
        {
            Loop_CastleWindsor(3);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0005()
        {
            Loop_CastleWindsor(5);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0008()
        {
            Loop_CastleWindsor(8);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0013()
        {
            Loop_CastleWindsor(13);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0021()
        {
            Loop_CastleWindsor(21);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0050()
        {
            Loop_CastleWindsor(50);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0100()
        {
            Loop_CastleWindsor(100);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0200()
        {
            Loop_CastleWindsor(200);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_0500()
        {
            Loop_CastleWindsor(500);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_1000()
        {
            Loop_CastleWindsor(1000);
            Assert.IsTrue(true);
        }

        [TestCategory("CastleWindsor"), TestMethod]
        public void TestAOP_CastleWindsor_2000()
        {
            Loop_CastleWindsor(2000);
            Assert.IsTrue(true);
        }

        #endregion


        #region "PostSharp"

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0001()
        {
            Loop_PostSharp(1);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0002()
        {
            Loop_PostSharp(2);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0003()
        {
            Loop_PostSharp(3);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0005()
        {
            Loop_PostSharp(5);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0008()
        {
            Loop_PostSharp(8);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0013()
        {
            Loop_PostSharp(13);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0021()
        {
            Loop_PostSharp(21);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0050()
        {
            Loop_PostSharp(50);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0100()
        {
            Loop_PostSharp(100);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0200()
        {
            Loop_PostSharp(200);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_0500()
        {
            Loop_PostSharp(500);
            Assert.IsTrue(true);
        }


        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_1000()
        {
            Loop_PostSharp(1000);
            Assert.IsTrue(true);
        }

        [TestCategory("PostSharp"), TestMethod]
        public void TestAOP_PostSharp_2000()
        {
            Loop_PostSharp(2000);
            Assert.IsTrue(true);
        }

        #endregion


        #region "WithoutAOP"

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0001()
        {
            Loop_WithoutAOP(1);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0002()
        {
            Loop_WithoutAOP(2);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0003()
        {
            Loop_WithoutAOP(3);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0005()
        {
            Loop_WithoutAOP(5);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0008()
        {
            Loop_WithoutAOP(8);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0013()
        {
            Loop_WithoutAOP(13);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0021()
        {
            Loop_WithoutAOP(21);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0050()
        {
            Loop_WithoutAOP(50);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0100()
        {
            Loop_WithoutAOP(100);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0200()
        {
            Loop_WithoutAOP(200);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_0500()
        {
            Loop_WithoutAOP(500);
            Assert.IsTrue(true);
        }


        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_1000()
        {
            Loop_WithoutAOP(1000);
            Assert.IsTrue(true);
        }

        [TestCategory("WithoutAOP"), TestMethod]
        public void TestAOP_WithoutAOP_2000()
        {
            Loop_WithoutAOP(2000);
            Assert.IsTrue(true);
        }

        #endregion



        private WindsorContainer _container;
        private WindsorContainer container
        {
            get
            {
                if (_container == null)
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

        private void Loop_CastleWindsor(int iterations)
        {
            LoopFunction(delegate
            {
                ISmsSender oSms = container.Resolve<ISmsSender>();
                oSms.Send("Hola mundo", "Hola mundo");

            }, iterations);
        }

        private void Loop_PostSharp(int iterations)
        {
            LoopFunction(delegate 
            {
                ISmsSender oSms = new SmsSenderPostSharp();
                oSms.Send("Hola mundo", "Hola mundo");

            }, iterations);
        }

        private void Loop_WithoutAOP(int iterations)
        {
            LoopFunction(delegate
            {
                ISmsSender oSms = new SmsSenderWithoutAOP();
                oSms.Send("Hola mundo", "Hola mundo");

            }, iterations);
        }


        private void LoopFunction(Action delegateFunction, int iterations)
        {
            int i = 0;
            for (i = 0; i < iterations; i++)
            {
                delegateFunction();
            }
        }

    }
}
