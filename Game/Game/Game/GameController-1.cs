using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameController
    {
        private string[][] CurrentLevel;
        private BoardObject LevelObjects;
        private int MoveCount;
        private bool IsPaused;
        private bool IsComplete;
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
        SaveGameState
        LoadGameState
        what is at? >> look in front of the player and if it is a block then look in front of that
        is completed

        load level calls to the filer, passes information to a builder, which builds a new level and then another function populates the created level.
        */

        public int GetWidth()
        {
            return this.CurrentLevel[0].Length;
        }

        public int GetHeight()
        {
            return this.CurrentLevel.Length;
        }

        public void Move()
        {

        }

        public void LoadLevel()
        {
            //call to the filer to load a level and return it. this will need to be saved to a variable here to be used later.
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

        public void WhatsAt()
        {
            //return the object in front of the player in the direction being moved.
            //if it's a block then also check behind the block to see if it can be moved.
        }

        public void Quit()
        {

        }

        public bool GetIsComplete()
        {
            return this.IsComplete;
        }

    }
}
