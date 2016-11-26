using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public class Loader : iLoader
    {

        private Filer MyFiler;

        public Loader(Filer theFiler)
        {
            MyFiler = theFiler;
        }

        public void Load(string fileName)
        {
            if (!MyFiler.MyHasLoaded)
            {
                MyFiler.MyLevels = ReadFile(fileName);
            }
        }

        private bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        private string ReadFile(string filename)
        {
            string[] res = null;
            string r = null;
            if (FileExists(filename))
            {
                res = File.ReadAllLines(@"" + filename);
            }
            MyFiler.MyHasLoaded = true;
            foreach (string x in res)
            {
                r += x;
            }
            return r;
        }
    }
}
