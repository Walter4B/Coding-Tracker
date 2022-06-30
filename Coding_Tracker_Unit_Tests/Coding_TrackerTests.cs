using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Coding_Tracker_Unit_Tests
{
    [TestClass]
    public class Coding_TrackerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = new CodingSession();

            Coding_Tracker.Program.Main();

            using (var sw = new StringWriter())
            { 
            
                Assert.IsInstanceOfType
            }
        }
    }
}
