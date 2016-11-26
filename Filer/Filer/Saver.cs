using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public class Saver : iSaver
    {
        private Filer MyFiler;

        public Saver(Filer theFiler)
        {
            MyFiler = theFiler;
        }
        public void Save(string filename/*, iFileable callMeBackforDetails*/)
        {
            StringBuilder sb = new StringBuilder();

                sb.Append(MyFiler.MyLevels);
                sb.Append("\n");

            using (StreamWriter outfile = new StreamWriter(filename))
            {
                outfile.Write(sb.ToString());
            }
        }
    }
}
