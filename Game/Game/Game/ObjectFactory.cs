using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ObjectFactory
    {
        private BoardObjects[] TheBoard;

        public void CreateObjects(string[][] theBoard)
        {
            TheBoard = new BoardObjects[theBoard.Length * theBoard[0].Length];
            int x = 0;
            for (int i = 0; i < theBoard.Length; i++)
            {
                for (int c = 0; c < theBoard[i].Length; c++)
                {
                    this.TheBoard[x] = new BoardObjects(c, i, this.GetType(theBoard[i][c]));
                    x++;
                }
            }
        }

        private string GetType(string cell)
        {
            switch (cell)
            {
                case "-":
                    return "Empty";
                case "@":
                    return "Player";
                case ".":
                    return "Goal";
                case "$":
                    return "Block";
                default:
                    return "Wall";
            }
        }

        public BoardObjects[] GetBoard()
        {
            return this.TheBoard;
        }
    }
}
