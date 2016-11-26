using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanFiler;

namespace FilerTests
{
    [TestClass]
    public class FileableTests
    {
        static Filer F;
        static Fileable Fl;

        public void RunAllLoaderTests(TestContext context)
        {
            ClassInit(context);
        }

        [ClassCleanup]
        public static void TestClean()
        {
            F = null;
            Fl = null;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            F = new Filer();
            Fl = new Fileable(F);
            F.MyLevels = new string[] { "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|" };
            F.MyCurLevelIndex = 0;
        }
        [TestMethod]
        public void TestColumnCount1()
        {
            int expected = 8;
            int actual = Fl.GetColumnCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRowCount1()
        {
            int expected = 9;
            int actual = Fl.GetRowCount();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCharAt1_1()
        {
            char expected = '-';
            char actual = Fl.WhatsAt(1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCharAt3_7()
        {
            char expected = '#';
            char actual = Fl.WhatsAt(3, 7);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCharAt4_6()
        {
            char expected = '*';
            char actual = Fl.WhatsAt(4, 6);
            Assert.AreEqual(expected, actual);
        }
    }
}
