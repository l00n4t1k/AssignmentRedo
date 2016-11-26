using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Game
{
    public class BoardBuilder
    {
        private BoardObject[] TheBoard;

        public void CreateBoard(string[][] theBoard)
        {
            ObjectBuilder fac = new ObjectBuilder();
            fac.CreateObjects(theBoard);
            this.TheBoard = fac.GetBoard();
        }

        public BoardObject[] GetTheBoard()
        {
            return this.TheBoard;
        }

        public string[][] stringConverter(string theLevel)
        {
            
            int z = 0;
            for (int i = 0; i < theLevel.Length; i++)
            {
                if (theLevel[i] == '|')
                    z++;
            }
            int pppp = (theLevel.Length) / z;
            string[] p = new string[pppp];
            string[][] res = new string[z][];
            int temp = 0;
            int c = 0;
            int x = 0;
            for (int i = 0; i < theLevel.Length; i++)
            {
                if (theLevel[temp] != '|' && temp < theLevel.Length)
                {
                    p[x] = theLevel[temp].ToString();
                    x++;
                    temp++;
                }
                else
                {
                    res[c] = p;
                    c++;
                    temp++;
                    x = 0;
                }
                    
                
            }
            return res;
        }
    }
}
