using System;
using System.Collections.Generic;

namespace DiezMil
{
    public class DiceRoll
    {
        private int score;
        private Dice keptDice;
        private Dice freeDice;
        private Dice toBeKeptDice;
        private Random randomDie;

        public DiceRoll()
        {
            score = 0;
            keptDice = new Dice();
            freeDice = new Dice();
            toBeKeptDice = new Dice();
            randomDie = new Random();
        }

        public void StartTurn()
        {
            keptDice.Clear();
            freeDice.Clear();
            toBeKeptDice.Clear();
            score = 0;
        }

        public void Roll()
        {
            freeDice.Clear();

            for(var i = 0; i < 5-keptDice.Count; i++)
            {
                freeDice.Add(randomDie.Next(1,6));
            }
            
            // freeDice.Add(1);
            // freeDice.Add(3);
            // freeDice.Add(3);
            // freeDice.Add(3);
            // freeDice.Add(4);
        }

        public void ShowRoll()
        {
            String auxString = "";

            if(keptDice.Count > 0)
            {
                Console.WriteLine("Kept dice:");
                foreach(var die in keptDice.dieList)
                {
                    auxString = auxString + die.ToString() + ",";
                }
                Console.WriteLine(auxString);
            }
            Console.WriteLine("Free dice:");
            auxString = "";
            foreach(var die in freeDice.dieList)
            {
                auxString = auxString + die.ToString() + ",";
            }
            Console.WriteLine(auxString); 
        }

        public bool HasScore()
        {
            if(freeDice.HasScore() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetKept(List<int> diceCombination)
        {
            if(validateDiceAmount(diceCombination) == false)
            {
                Console.WriteLine("You inputted a wrong number of dice. Try again.");
                return false;
            }
            else if(validateDiceCombination(diceCombination) == true)
            {
                toBeKeptDice.Clear();

                foreach(var die in diceCombination)
                {
                    toBeKeptDice.Add(freeDice.dieList[die-1]);
                }
                updateScore(toBeKeptDice);

                foreach(var die in diceCombination)
                {
                    keptDice.Add(freeDice.dieList[die-1]);
                }
                freeDice.Clear();

                if(keptDice.Count == 5)
                {
                    keptDice.Clear();
                }
            }

            return true;
        }

        internal void ShowKeptDice()
        {
            String auxString = "";

            Console.WriteLine("Kept dice:");
            foreach(var die in keptDice.dieList)
            {
                auxString = auxString + die.ToString() + ",";
            }
            Console.WriteLine(auxString);
            
        }

        private bool validateDiceCombination(List<int> diceCombination)
        {
            return true;
        }

        private bool validateDiceAmount(List<int> diceCombination)
        {
            if(diceCombination.Count > 0 && diceCombination.Count <= freeDice.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int calculateScore(Dice dice)
        {
            var score = 0;
            dice.findNumbersAndLeg();
            if(dice.isStairs() == true)
            {
                score = score + 500;
            }
            else
            {
                switch(dice.leg)
                {
                    case 6:
                        score = score + dice.numbers[0] * 100 + dice.numbers[4] * 50;
                        break;

                    case 0:
                        score = score + 1000 + (dice.numbers[0] - 3) * 100 + dice.numbers[4] * 50;
                        break;

                    case 4:
                        score = score + 500 + dice.numbers[0] * 100 + (dice.numbers[4]- 3) * 50;
                        break;

                    default: 
                        score = score + (dice.leg + 1) * 100 + dice.numbers[0] * 100 + dice.numbers[4] * 50;
                        break;

                }
            }
            

            return score;
        }

        private void updateScore(Dice dice)
        {
            score += calculateScore(dice);
        }

        private void clearScore()
        {
            score = 0;
        }

        public int GetScore()
        {
            return score;
        }
    }
}