using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanFiler;

namespace FilerTests
{
    [TestClass]
    public class LoaderTests
    {
        static Filer F;
        static Saver S;
        static Loader L;

        //[TestMethod]
        public void RunAllLoaderTests(TestContext context)
        {
            ClassInit(context);
            TestLoadFromFile01_BypassFiler();
            TestLoadForm02_FromFiler_Level1();
        }

        [ClassCleanup]
        public static void TestClean()
        {
            F = null;
            S = null;
            L = null;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            F = new Filer();
            S = F.GetMySaver();
            L = F.GetMyLoader();
            F.MyLevels = new string[] { "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|" };
            S.Save("F:\\TestFiles\\LoaderTestInitFile.txt");
            F.MyLevels = null;
            F.MyFilePath = "F:\\TestFiles";
        }

        [TestMethod]
        public void TestLoadFromFile01_BypassFiler()
        {
            string[] expected = new string[] { "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|" };
            L.Load("F:\\TestFiles\\LoaderTestInitFile.txt");
            string[] res = F.MyLevels;
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void TestLoadForm02_FromFiler_Level1()
        {
            string[] expected = new string[] { "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|" };
            F.Load("LoaderTestInitFile", 1);
            string[] res = F.MyLevels;
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestLoadNonExistantFile()
        {
            F.Load("LoaderTestNoFile", 1);
        }

    }
}