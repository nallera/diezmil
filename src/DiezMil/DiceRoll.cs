using System;
using System.Collections.Generic;
using System.Linq;

namespace DiezMil
{
    public class DiceRoll
    {
        private int score;
        private Dice keptDice;
        private Dice freeDice;
        private Dice toBeKeptDice;
        private Dice diceToValidate;
        private int[] indexesToValidate;
        private Random randomDie;

        public DiceRoll()
        {
            score = 0;
            keptDice = new Dice();
            freeDice = new Dice();
            toBeKeptDice = new Dice();
            diceToValidate = new Dice();
            randomDie = new Random();
            indexesToValidate = new int[5] {0,0,0,0,0};
        }

        public void StartTurn()
        {
            keptDice.Clear();
            freeDice.Clear();
            toBeKeptDice.Clear();
            diceToValidate.Clear();
            for(int i = 0; i < 5; i++)
            {
                indexesToValidate[i] = 0;
            }
            score = 0;
        }

        public void Roll()
        {
            freeDice.Clear();

            if(keptDice.Count == 5)
            {
                keptDice.Clear();
            }

            for(var i = 0; i < 5-keptDice.Count; i++)
            {
                freeDice.Add(randomDie.Next(1,7));
            }

            
            
            // freeDice.Add(1);
            // freeDice.Add(3);
            // freeDice.Add(3);
            // freeDice.Add(3);
            // freeDice.Add(4);
        }

        public void ShowRoll()
        {
            if(keptDice.Count > 0)
            {
                keptDice.showDice("Kept dice",false);
            }
            if(freeDice.Count > 0)
            {
                freeDice.showDice("Free dice",true);
            }
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
                    keptDice.Add(freeDice.dieList[die-1]);
                }
                updateScore(toBeKeptDice);

                return true;
            }
            else
            {
                return false;
            }
        }

        internal void ShowKeptDice()
        {
            keptDice.showDice("Kept dice",false);
        }

        private bool validateDiceCombination(List<int> diceCombination)
        {
            for(int i = 0; i < 5; i++)
            {
                indexesToValidate[i] = 0;
            }

            diceToValidate.Clear();

            foreach(var die in diceCombination)
            {
                indexesToValidate[die-1]++;
                diceToValidate.Add(freeDice.dieList[die-1]);
            }

            diceToValidate.findNumbersAndLeg();

            //repeticion de numeros 
            if(indexesToValidate.Max() > 1) 
            {
                Console.WriteLine("You entered an index more than once. Try again.");
                return false;
            }
            //2,3,4 o 6 si no hay 3 de esos o escalera
            else if(diceToValidate.stairs == false)
            {
                if(diceToValidate.leg != 1 && diceToValidate.numbers[1] > 0)
                {
                    Console.WriteLine("You cannot select 2s unless there's a leg or a stair. Try again.");
                    return false;
                }
                else if(diceToValidate.leg != 2 && diceToValidate.numbers[2] > 0)
                {
                    Console.WriteLine("You cannot select 3s unless there's a leg or a stair. Try again.");
                    return false;
                }
                else if(diceToValidate.leg != 3 && diceToValidate.numbers[3] > 0)
                {
                    Console.WriteLine("You cannot select 4s unless there's a leg or a stair. Try again.");
                    return false;
                }
                else if(diceToValidate.leg != 5 && diceToValidate.numbers[5] > 0)
                {
                    Console.WriteLine("You cannot select 6s unless there's a leg or a stair. Try again.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else 
            {
                return true;
            }
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
            if(dice.stairs== true)
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