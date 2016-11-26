using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanFiler;
using System.IO;

namespace FilerTests
{
    [TestClass]
    public class SaverTests
    {
        static Filer f;
        static Saver s;
        //protected Filer f;
        //protected Saver s;

        //[TestMethod]
        public void RunAllSaverTests(TestContext context)
        {
            ClassInit(context);
            CheckCreatesFile();
            CheckNotCreatesFile();
        }

        [ClassCleanup]
        public static void TestClean()
        {
            f = null;
            s = null;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            f = new Filer();
            s = f.GetMySaver();
            f.MyLevels = new string[] { "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|" };

        }

        [TestMethod]
        public void CheckCreatesFile()
        {

            f.GetMySaver().Save("F:\\TestFiles\\CheckCreatesFile.txt");
            bool res = File.Exists("F:\\TestFiles\\CheckCreatesFile.txt");

            Assert.AreEqual(true, res);
        }

        [TestMethod]
        public void CheckNotCreatesFile()
        {
            bool res = File.Exists("F:\\TestFiles\\CheckCreatesFile2.txt");

            Assert.AreEqual(false, res);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void TestSaveToNonExistantFolder()
        {
            f.GetMySaver().Save("F:\\TestFiles2\\CheckCreatesFile.txt");
        }
    }
}