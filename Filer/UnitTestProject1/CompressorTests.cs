using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SokobanFiler;

namespace FilerTests
{
    [TestClass]
    public class CompressorTests
    {

        public void RunAllCompressorTests()
        {
            TestCompressor01();
            TestCompressor02();
            TestExpander01();
            TestExpander02();
            SinglesAreNotCompressed();
            ShortRunCompression();
            LongRunCompression();
            RunsAndSinglesCompression();
            TwoLinesCompressedToOne();
            RemoveTrailingBlanksWhenCompressing();
        }

        [TestMethod]
        public void TestCompressor01()
        {
            iConverter theConverter = new Converter();
            string testString = "--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|";
            theConverter.Compress(testString);
            string res = theConverter.Compressed;
            Assert.AreEqual("2-5#|3#3-#|#2-*#-2#|#-#2-*-#|#-*2-#-#|2#-#+2-#|-#3-$2#|-3#2-#|3-4#|", res);
        }

        [TestMethod]
        public void TestCompressor02()
        {
            iConverter theConverter = new Converter();
            string testString = "aaabcccc";
            theConverter.Compress(testString);
            string res = theConverter.Compressed;
            Assert.AreEqual("3ab4c", res);
        }

        [TestMethod]
        public void TestExpander01()
        {
            iConverter theConverter = new Converter();
            string testString = "2-5#|3#3-#|#2-*#-2#|#-#2-*-#|#-*2-#-#|2#-#+2-#|-#3-$2#|-3#2-#|3-4#|";
            theConverter.Expand(testString);
            string res = theConverter.Expanded;
            Assert.AreEqual("--#####|###---#|#--*#-##|#-#--*-#|#-*--#-#|##-#+--#|-#---$##|-###--#|---####|", res);
        }

        [TestMethod]
        public void TestExpander02()
        {
            iConverter theConverter = new Converter();
            string testString = "3ab4cd2e2fg2h";
            theConverter.Expand(testString);
            string res = theConverter.Expanded;
            Assert.AreEqual("aaabccccdeeffghh", res);
        }

        [TestMethod]
        public void SinglesAreNotCompressed()
        {
            string input = "##.@+$-*";
            string expected = "2#.@+$-*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Did not leave singles alone");
        }

        [TestMethod]
        public void ShortRunCompression()
        {
            string input = "###...@@@+++$$$---***";
            string expected = "3#3.3@3+3$3-3*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 3 symbols were not compressed to digit and symbol pairs");
        }

        [TestMethod]
        public void LongRunCompression()
        {
            string input = "##########..........@@@@@@@@@@++++++++++$$$$$$$$$$----------**********";
            string expected = "10#10.10@10+10$10-10*"; ;
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Runs of 10 symbols were not compressed to digits followed by a symbol");
        }

        [TestMethod]
        public void RunsAndSinglesCompression()
        {
            string input = "###.@@@+$$$-***";
            string expected = "3#.3@+3$-3*";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "runs were not compressed and singles left alone");
        }

        [TestMethod]
        public void TwoLinesCompressedToOne()
        {
            string input = "#######\n#.@-#-#";
            string expected = "7#|#.@-#-#";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Line seperator not right");
        }

        [TestMethod]
        public void RemoveTrailingBlanksWhenCompressing()
        {
            string input = "#######\n#.@-#-# ";
            string expected = "7#|#.@-#-#";
            Converter compressor = new Converter();
            // act
            compressor.Compress(input);
            string actual = compressor.Compressed;
            // assert
            Assert.AreEqual(expected, actual, "Trailing Blanks at end of line");
        }

    }
}
