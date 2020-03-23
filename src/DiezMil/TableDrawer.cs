using System;
using System.Collections.Generic;

namespace DiezMil
{
    internal class TableDrawer
    {
        internal static void drawRoof()
        {
            Console.WriteLine("╔═════════════╦═══╦═══╦═══╦═══╦═══╗");
        }

        internal static void drawID(int count)
        {
            switch(count)
            {
                case 1:
                    Console.WriteLine("║   Dice ID   ║ 1 ║ x ║ x ║ x ║ x ║");
                    break;
                
                case 2:
                    Console.WriteLine("║   Dice ID   ║ 1 ║ 2 ║ x ║ x ║ x ║");
                    break;
                
                case 3:
                    Console.WriteLine("║   Dice ID   ║ 1 ║ 2 ║ 3 ║ x ║ x ║");
                    break;
                
                case 4:
                    Console.WriteLine("║   Dice ID   ║ 1 ║ 2 ║ 3 ║ 4 ║ x ║");
                    break;
                
                case 5:
                    Console.WriteLine("║   Dice ID   ║ 1 ║ 2 ║ 3 ║ 4 ║ 5 ║");
                    break;
            }
            
        }

        internal static void drawMiddle()
        {
            Console.WriteLine("╠═════════════╬═══╬═══╬═══╬═══╬═══╣");
        }

        internal static void drawNumber(List<int> dieList)
        {
            switch(dieList.Count)
            {
                case 1:
                    Console.WriteLine($"║ Dice Number ║ {dieList[0]} ║ x ║ x ║ x ║ x ║ ");
                    break;
                
                case 2:
                    Console.WriteLine($"║ Dice Number ║ {dieList[0]} ║ {dieList[1]} ║ x ║ x ║ x ║ ");
                    break;
                
                case 3:
                    Console.WriteLine($"║ Dice Number ║ {dieList[0]} ║ {dieList[1]} ║ {dieList[2]} ║ x ║ x ║ ");
                    break;
                
                case 4:
                    Console.WriteLine($"║ Dice Number ║ {dieList[0]} ║ {dieList[1]} ║ {dieList[2]} ║ {dieList[3]} ║ x ║ ");
                    break;
                
                case 5:
                    Console.WriteLine($"║ Dice Number ║ {dieList[0]} ║ {dieList[1]} ║ {dieList[2]} ║ {dieList[3]} ║ {dieList[4]} ║ ");
                    break;
            } 
        }

        internal static void drawFloor()
        {
            Console.WriteLine("╚═════════════╩═══╩═══╩═══╩═══╩═══╝");
        }

        internal static void drawScoreRoof()
        {
            Console.WriteLine("╔════════════╦════════════╗");
        }

        internal static void drawScoreNames()
        {
            Console.WriteLine("║    User    ║    Bot     ║");
        }

        internal static void drawScoreMiddle()
        {
            Console.WriteLine("╠════════════╬════════════╣");
        }

        internal static void drawScorePoints(int n1, int n2)
        {   
            var aux = 0;

            if(n1 == 0)
            {
                aux = 0;
            }
            else
            {   
                aux = Convert.ToInt32(Math.Floor(Math.Log10(n1)));
            }
            
            var space1 = new String(' ',7-aux);

            if(n2 == 0)
            {
                aux = 0;
            }
            else
            {   
                aux = Convert.ToInt32(Math.Floor(Math.Log10(n2)));
            }
            
            var space2 = new String(' ',7-aux);

            Console.WriteLine($"║    {n1}{space1}║    {n2}{space2}║");
        }

        internal static void drawScoreFloor()
        {
            Console.WriteLine("╚════════════╩════════════╝");
        }



    }
}