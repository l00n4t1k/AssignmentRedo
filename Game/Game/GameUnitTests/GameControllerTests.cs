using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game;
namespace GameUnitTests
{
    [TestClass]
    public class GameControllerUnitTest
    {
        // Player is at row 4 col 4 (3,3 with array indexing)
        static string TheLevel = "--#####|###---#|#--*#-#|#-#@-*-|#-*$-##|##-#.-#|-#---$#|-###-#|---####|";
        [TestMethod]
        public void Test_Load_Level()
        {
            GameController gC = new GameController();
            BoardBuilder bB = new BoardBuilder();
            gC.LoadLevel("F:\\TestFiles", "GameControllerTest");
            string[][] actual = gC.myCurrentLevel;
            string[][] expected = bB.stringConverter(TheLevel);
            CollectionAssert.Equals(actual, expected);
            

        }
    }
}
