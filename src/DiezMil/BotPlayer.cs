using System;

namespace DiezMil
{
    public class BotPlayer
    {
        private int score;
        private Dice dice;

        public BotPlayer()
        {
            score = 0;
            dice = new Dice();
        }

        public int GetScore()
        {
            return score;
        }

        public void PlayTurn()
        {
            
        }

        internal void SelectBehavior()
        {
            
        }
    }
}