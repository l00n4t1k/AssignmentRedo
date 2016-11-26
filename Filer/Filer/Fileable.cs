using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanFiler
{
    public class Fileable : iFileable
    {

        private Filer MyFiler;
        private string CurrentLevel;
        private string[] SplitLevel;

        public Fileable(Filer theFiler)
        {
            MyFiler = theFiler;
        }

        public int GetColumnCount()
        {
            GetCurrentLevel();
            int maxCols = 0;
            foreach (string element in SplitLevel)
            {
                if (element.Length > maxCols)
                    maxCols = element.Length;
            }
            return maxCols;
        }

        public int GetRowCount()
        {
            GetCurrentLevel();
            return (int)SplitLevel.Length;
        }

        public char WhatsAt(int row, int column)
        {
            GetCurrentLevel();
            return SplitLevel[row - 1][column - 1];
        }

        private void GetCurrentLevel()
        {
            string[] separator = new string[] {"|"};
            CurrentLevel = MyFiler.MyLevels[MyFiler.MyCurLevelIndex].ToString();
            SplitLevel = CurrentLevel.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
