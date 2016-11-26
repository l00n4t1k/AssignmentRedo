using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FilerTests
{
    [TestClass]
    public class TestController
    {
        /*
        ignore this test class. was trying to get all tests in the 
        other classes running by calling a single method. decided to
        not waste any more time on it at this stage
        */
        static LoaderTests l;
        static SaverTests s;
        static CompressorTests c;
        public TestContext TestContext { get; set; }
        private static TestContext _testContext;

        [ClassCleanup]
        public static void Cleanup()
        {
            l = null;
            s = null;
            c = null;
        }

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _testContext = context;
            l = new LoaderTests();
            s = new SaverTests();
            c = new CompressorTests();
        }
        [TestMethod]
        public void RunAllLoader()
        {
            l.RunAllLoaderTests(_testContext);
        }

        [TestMethod]
        public void RunAllSaver()
        {
            s.RunAllSaverTests(_testContext);
        }

        [TestMethod]
        public void RunAllCompressor()
        {
            c.RunAllCompressorTests();
        }
    }
}
