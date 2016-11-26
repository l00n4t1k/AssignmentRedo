using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public class Filer : iFiler
    {

        protected Loader MyLoader;
        protected Saver MySaver;
        protected Converter MyConverter;

        public Filer()
        {
            MyLoader = new Loader(this);
            MySaver = new Saver(this);
            MyConverter = new Converter();
        }

        private int curLevelIndex;

        public int MyCurLevelIndex
        {
            get { return curLevelIndex; }
            set { curLevelIndex = value; }
        }

        private string filepath;

        public string MyFilePath
        {
            get { return filepath; }
            set { filepath = value; }
        }

        private string allLevels;

        public string MyLevels
        {
            get { return allLevels; }
            set { allLevels = value; }
        }

        private bool HasLoaded;

        public bool MyHasLoaded
        {
            get { return HasLoaded; }
            set { HasLoaded = value; }
        }

        public Saver GetMySaver()
        {
            return MySaver;
        }

        public Loader GetMyLoader()
        {
            return MyLoader;
        }

        public string Load(string filename)
        {
            //curLevelIndex = levelNum - 1;
            filename = MyFilePath + "\\" + filename + ".txt";
            MyLoader.Load(filename);
            return MyLevels;
            /*steps for loading...
             * 1. open file
             * 2. read file to variable
             * 3. uncompress level
             * 4. return uncompressed level
             * */
        }

        public void Save(string filename/*, iFileable theFile*/)
        {
            filename = MyFilePath + "\\" + filename + ".txt";
            /*steps for saving...
             * 1. take level string and compress
             * 2. open file
             * 3. write compressed level string to file
             * */
            MySaver.Save(filename);
        }

        public void SetFilepath(string path)
        {
            filepath = path;
        }

    }
}
