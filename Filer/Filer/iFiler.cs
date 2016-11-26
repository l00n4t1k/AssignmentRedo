using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public interface iFiler
    {
        void SetFilepath(string path);
        void Save(string filename/*, iFileable theFile*/);
        string Load(string filename);
    }
}
