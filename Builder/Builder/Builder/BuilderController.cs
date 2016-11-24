using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class BuilderController
    {
        private int Height;

        public int MyHeight
        {
            get { return Height; }
            set { Height = value; }
        }

        private int Width;

        public int MyWidth
        {
            get { return Width; }
            set { Width = value; }
        }

        public void Save()
        {
            //send information to the filer.
        }

        public void Load()
        {
            //call to the filer and get level information for editing.
        }


        /*
        Input Height
        input Max Width
        select object type
        add selected type
        Send save to filer
        receive load from filer
        */
    }
}
