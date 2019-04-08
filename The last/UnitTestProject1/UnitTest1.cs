using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string s = "3＋3";
            string reult = "6";
            Assert.AreEqual(reult,ConsoleApp1.CM10.Shunting(s).ToString());
        }
    }

    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod2()
        {
            string s = "9/3＋12/3";
            string reult = "7";
            Assert.AreEqual(reult, ConsoleApp1.CM10.Shunting(s).ToString());
        }
    }
}
