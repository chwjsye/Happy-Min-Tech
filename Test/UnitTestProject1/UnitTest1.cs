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
            string s = "9614/9130/370";
            string reult = "6";
            Assert.AreEqual(reult,ConsoleApp1.CM10.Shunting(s).ToString());
        }
    }

  
}
