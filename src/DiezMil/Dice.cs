using System;
using System.Collections.Generic;

namespace DiezMil
{
    internal class Dice
    {
        public List<int> dieList;
        public int[] numbers;
        public int leg;
        public int Count;
        public bool stairs;

        public Dice()
        {
            dieList = new List<int>();
            numbers = new int[6];
            leg = 6;
            Count = 0;
            stairs = false;
        }


        public void findNumbersAndLeg()
        {
            for(int i = 0; i < 6; i++)
            {
                numbers[i] = 0;
            }
            foreach(var die in dieList)
            {
                numbers[die-1]++;
            }

            for(int i = 0; i < 6; i++)
            {   
                if(numbers[i] >= 3)
                {
                    leg = i;
                    break;
                }
            }
            
            stairs = isStairs();
        }

        internal void Add(int die)
        {
            dieList.Add(die);
            Count = dieList.Count;
        }

        internal void Clear()
        {
            dieList.Clear();
            for(int i = 0; i < 5; i++)
            {
                numbers[i] = 0;
            }
            leg = 6;
            Count = 0;
        }

        internal bool HasScore()
        {
            findNumbersAndLeg();

            if(numbers[0] > 0 || numbers[4] > 0  || leg < 6 || stairs == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool isStairs()
        {
            if(Count == 5 && ((numbers[1] == 1 && numbers[2] == 1 && numbers[3] == 1 && numbers[4] == 1) && (numbers[0] == 1 || numbers[5] == 1)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void showDice(string diceName,bool diceID)
        {
            if(diceID == true)
            {
                Console.WriteLine($"{diceName}:");
                TableDrawer.drawRoof();
                TableDrawer.drawID(Count);
                TableDrawer.drawMiddle();
                TableDrawer.drawNumber(dieList);
                TableDrawer.drawFloor();
            }
            else
            {
                Console.WriteLine($"{diceName}:");
                TableDrawer.drawRoof();
                TableDrawer.drawNumber(dieList);
                TableDrawer.drawFloor();
            }
        }
    }
}