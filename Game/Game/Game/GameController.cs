using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SokobanFiler;

namespace Game
{
    public class GameController
    {
        private string[][] CurrentLevel;
        private string[][] StartingLevel;
        private string[][] Undo1;
        private string[][] Undo2;
        private BoardObject levelObjects;
        private int MoveCount;
        private bool IsPaused = false;
        private bool IsComplete;
        private int PlayerLocationY;
        private int PlayerLocationX;
        private ObjectBuilder oB = new ObjectBuilder();
        private BoardBuilder bB = new BoardBuilder();
        private int UndoCounter;

        public int MyPlayerLocationX
        {
            get { return PlayerLocationX; }
            set { PlayerLocationX = value; }
        }
        public int MyPlayerLocationY
        {
            get { return PlayerLocationY; }
            set { PlayerLocationY = value; }
        }

        public string[][] myCurrentLevel
        {
            get { return CurrentLevel; }
            set { CurrentLevel = value; }
        }

        /*
        >>move
        >>LoadLevel
        >>RestartGame
        >>Undo
        >>GetHeight
        >>GetWidth
        >>Quit
        >>GetMoves
        GetTime
        >>Pause
        >>SaveGameState
        >>LoadGameState will be done with LoadLevel
        >>what is at? >> look in front of the player and if it is a block then look in front of that
        >>is completed
        load level calls to the filer, passes information to/from a builder, which builds a new level and then another function populates the created level.
        */

        public int GetWidth()
        {
            return this.CurrentLevel[0].Length;
        }

        public int GetHeight()
        {
            return this.CurrentLevel.Length;
        }
        public void UndoFunction()
        {
            Undo2 = Undo1;
            Undo1 = CurrentLevel;
            if (UndoCounter < 2)
            {
                UndoCounter++;
            }

        }

        public void Move(int x, int y, int x2, int y2, int playerLocationXY)
        {
            if (WhatsAt(MyPlayerLocationX + x, MyPlayerLocationY + y) != "Wall" && IsPaused == false)
            {
                if (WhatsAt(MyPlayerLocationX + x, MyPlayerLocationY + y) == "Block")
                {
                    if (WhatsAt(MyPlayerLocationX + x2, MyPlayerLocationY + y2) != "Wall")
                    {
                        playerLocationXY = playerLocationXY + (x + y);
                        UndoFunction();
                    }
                }
                else
                {
                    playerLocationXY = playerLocationXY + (x + y);
                    UndoFunction();
                }
            }
        }

        public void MoveLeft()
        {
            Move(-1, 0, -2, 0, MyPlayerLocationX);
        }

        public void MoveRight()
        {
            Move(1, 0, 2, 0, MyPlayerLocationX);
    
        }
        public void MoveUp()
        {
            Move(0, -1, 0, -2, MyPlayerLocationY);
        }
        public void MoveDown()
        {
            Move(0, 1, 0, 2, MyPlayerLocationY);
            //if (WhatsAt(MyPlayerLocationX, MyPlayerLocationY + 1) != "Wall" && IsPaused == false)
            //{
            //    if (WhatsAt(MyPlayerLocationX, MyPlayerLocationY) == "Block")
            //    {
            //        if (WhatsAt(MyPlayerLocationX, MyPlayerLocationY + 2) != "Wall")
            //        {
            //            MyPlayerLocationY = MyPlayerLocationY + 1;
            //            UndoFunction();
            //        }
            //    }
            //    else
            //    {
            //        MyPlayerLocationY = MyPlayerLocationY + 1;
            //        UndoFunction();
            //    }

            //}
        }

        public void LoadLevel(string path, string name)
        {
            //call to the filer to load a level and return it. this will need to be saved to a variable here to be used later. will pass the string into the create
            //objects function inside object builder
            //will assign the map to the class level variable CurrentLevel and StartingLevel.
            iFiler theFiler = new Filer();
            //Console.WriteLine("Enter a filepath");
            //string path = Console.ReadLine();
            theFiler.SetFilepath(path);
            //Console.WriteLine("Enter a filename");
            //string name = Console.ReadLine();
            string theLevel = theFiler.Load(name);
            CurrentLevel = bB.stringConverter(theLevel);
            StartingLevel = CurrentLevel;
            FindPlayer();
        }

        private void FindPlayer()
        {
            for (int i = 0; i < CurrentLevel.Length; i++)
            {
                for (int c = 0; c < CurrentLevel[0].Length; c++)
                {
                    if(CurrentLevel[i][c] == "@")
                    {
                        MyPlayerLocationX = c;
                        MyPlayerLocationY = i;
                        break;
                    }
                }
            }
        }

        public void StartLevel()
        {
            // reads current level and starts the building process for the level. should be able to be used for restart as well. Start timer
            this.IsPaused = false;
            this.MoveCount = 0;
        }

        public void Undo()
        {
            //undo up to 2 moves. keep a copy of the current board state to revert to, possibly use mod to determine array position to save
            CurrentLevel = Undo1;
            Undo1 = Undo2;
            Undo2 = null;
            UndoCounter--;
        }

        public void Pause()
        {
            //stop the timer and prevent any moves from being made
            this.IsPaused = !this.IsPaused;
        }

        public bool GetIsPaused()
        {
            return this.IsPaused;
        }

        public int GetMoveCount()
        {
            return this.MoveCount;
        }

        public String WhatsAt(int playerCoOrdX, int playerCoOrdY)
        {
            //return the object in front of the player in the direction being moved.
            //if it's a block then also check behind the block to see if it can be moved.
            return oB.GetType(CurrentLevel[playerCoOrdY][playerCoOrdX]);
        }

        public void Quit()
        {
            //return to the filer gui after doing the generic are you sure you want to quit.
        }
        public void isCompleted()
        {
            //check that all the moveable blocks are on top of the goal blocks.
            //maybe make a parent function for move functions so we can call this once instead of a 100000000 times, thus also reducing the amount of dup code in move
            //make an array of all the goal blocks position so they can be checked against the currentLevel array to see if all the moveable blocks are in the same location as the Goal Blocks.
        }
        public bool GetIsComplete()
        {
            return this.IsComplete;
        }

        public void SaveGameState()
        {
            //Take CurrentLevel and send it to the filer to save it at a pre-determined location.
        }
    }
}
