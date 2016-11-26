using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoardObject
    {

        public BoardObject(int x, int y, string type)
        {
            this.MyXCoord = x;
            this.MyYCoord = y;
            this.MyType = type;
        }

        private int XCoord;
        public int MyXCoord
        {
            get { return XCoord; }
            set { XCoord = value; }
        }

        private int YCoord;
        public int MyYCoord
        {
            get { return YCoord; }
            set { YCoord = value; }
        }

        private string Type;
        public string MyType
        {
            get { return Type; }
            set { Type = value; }
        }


    }
}
