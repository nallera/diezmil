using System;

namespace DiezMil
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            game.SelectOption();
            
            switch(game.GetOption())
            {
                case "1":
                    game.PlayAgainstBot();
                    break;

                case "2":
                    game.CheckStrategy();
                    break;

            }
        }
    }
}
