using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;

namespace GameUnitTests
{
    [TestClass]
    public class BoardBuilderTests
    {

        static string[] x;
        static string[] y;
        static string[][] testLevel;

        [ClassCleanup]
        public static void TestClean()
        {
            x = null;
            y = null;
            testLevel = null;
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            x = new string[] { "#", "@" };
            y = new string[] { "-", "#" };
            testLevel = new string[][] { x, y };
        }
        [TestMethod]
        public void Test_Element_Is_Correct_Object_Type()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[1];
            Assert.IsInstanceOfType(b1, typeof(BoardObject));
        }

        [TestMethod]
        public void Test_Element_Has_Correct_X_Coord()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[1];
            Assert.AreEqual(b1.MyXCoord, 0);
        }

        [TestMethod]
        public void Test_Element_Has_Correct_Y_Coord()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[1];
            Assert.AreEqual(b1.MyYCoord, 0);
        }

        [TestMethod]
        public void Test_Player_Has_Correct_X_Coord()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[0];
            Assert.AreEqual(b1.MyXCoord, 1);
        }

        [TestMethod]
        public void Test_Player_Has_Correct_Y_Coord()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[0];
            Assert.AreEqual(b1.MyYCoord, 0);
        }

        [TestMethod]
        public void Test_Element_Has_Correct_Type()
        {
            BoardBuilder b = new BoardBuilder();
            b.CreateBoard(testLevel);
            BoardObject[] theBoard = b.GetTheBoard();
            BoardObject b1 = theBoard[1];
            Assert.AreEqual(b1.MyType, "Wall");
        }
    }
}
