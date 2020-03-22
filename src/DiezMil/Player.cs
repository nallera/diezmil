using System;
using System.Collections.Generic;
using System.Linq;

namespace DiezMil
{
    internal class Player
    {
        private int score;
        private DiceRoll diceRoll;
        private List<int> diceCombination;

        public Player()
        {
            score = 0;
            diceRoll = new DiceRoll();
            diceCombination = new List<int>();
        }

        public int GetScore()
        {
            return score;
        }

        public void PlayTurn()
        {
            diceRoll.StartTurn();
            diceCombination.Clear();
            String keepRolling;
            
            while(true)
            {
                diceRoll.Roll();

                Console.WriteLine("Your roll:");
                diceRoll.ShowRoll();

                if(diceRoll.HasScore() == true)
                {
                    while(true)
                    {
                        Console.WriteLine("Which dice do you want to keep? Write the IDs separated by commas:");
                        while(true)
                        {
                            try
                            {
                                diceCombination = Array.ConvertAll(Console.ReadLine().Split(','), int.Parse).ToList();
                                break;
                            }
                            catch(FormatException ex)
                            {
                                Console.WriteLine(ex);
                                Console.WriteLine("Wrong format. Try again.");
                            }
                        }

                        if(diceRoll.SetKept(diceCombination) == true)
                        {
                            break;
                        }
                    }
                    
                    diceRoll.ShowKeptDice();
                    Console.WriteLine($"You're scoring {diceRoll.GetScore()} points in this turn. Do you want to keep rolling? (y/n)");

                    while(true)
                    {
                        keepRolling = Console.ReadLine();
                        if(keepRolling == "y" || keepRolling == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Do you want to keep rolling? (y/n)");
                        }
                    }

                    if(keepRolling == "n")
                    {
                        AddScore(diceRoll.GetScore());
                        Console.WriteLine($"You scored {diceRoll.GetScore()} points in this turn!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Your roll had 0 score, that's the end of your turn :(");
                    break;
                }

            }

        }

        private void AddScore(int score)
        {
            this.score += score;
        }
    }
}