using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoardBuilder
    {
        private BoardObjects[] TheBoard;

        public void CreateBoard(string[][] theBoard)
        {
            ObjectFactory fac = new ObjectFactory();
            fac.CreateObjects(theBoard);
            this.TheBoard = fac.GetBoard();
        }

        public BoardObjects[] GetTheBoard()
        {
            return this.TheBoard;
        }
    }
}
