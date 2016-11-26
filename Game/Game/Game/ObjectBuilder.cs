using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ObjectBuilder
    {
        private BoardObject[] TheBoard;

        public void CreateObjects(string[][] theBoard)
        {
            TheBoard = new BoardObject[theBoard.Length * theBoard[0].Length];
            int x = 1;
            for (int i = 0; i < theBoard.Length; i++)
            {
                for (int c = 0; c < theBoard[i].Length; c++)
                {
                    string type = this.GetType(theBoard[i][c]);
                    if (type == "Player")
                        this.TheBoard[0] = new BoardObject(c, i, type);
                    else
                    {
                        this.TheBoard[x] = new BoardObject(c, i, type);
                        x++;
                    }
                }
            }
        }

        public string GetType(string cell)
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

        public BoardObject[] GetBoard()
        {
            return this.TheBoard;
        }
    }
}
