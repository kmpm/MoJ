using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoJ;
using Newtonsoft.Json;

namespace MoJLib.Test
{
    
    
    /// <summary>
    ///This is a test class for ConfigTest and is intended
    ///to contain all ConfigTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ExecutorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [TestMethod]
        public void TestMouse()
        {
            var a = new MoJ.Action{
                Method = ActionMethod.MouseButtonClick,
                Data = "@right",
                Delay=1000
            };

            MoJ.Executor.Run(a);
        }

        [TestMethod]
        public void TestKey()
        {

            var a = new MoJ.Action
            {
                Method = ActionMethod.KeyPress,
                Data = "{shift}@"
            };

            var list = MoJ.Executor.parseKeyboardData(a.Data);
            
            Assert.AreEqual(NativeWIN32.INPUT_KEYBOARD, list[0].type);
            Assert.AreEqual((ushort)NativeWIN32.VK.SHIFT, list[0].ki.wVk);
            //Assert.AreEqual(MoJ.VirtualKeys.VK_SHIFT, list[0].VirtualKey);
            //Assert.AreEqual(MoJ.Executor.KEYBDEVENTF_SHIFTSCANCODE, list[0].ScanCode);


            //b = MoJ.Executor.fromHelper(list[1]);
            //Assert.AreEqual(MoJ.VirtualKeys.VK_SHIFT, list[1].VirtualKey);
            //Assert.AreEqual(MoJ.Executor.KEYBDEVENTF_SHIFTSCANCODE, list[1].ScanCode);
        }

    }
}
