using System;

namespace DiezMil
{
    public class Game
    {
        private string option;

        public Game()
        {
            option = "";
        }

        public void SelectOption()
        {
            Console.WriteLine("Play against the bot = 1\nCheck best strategy = 2\nQuit = q");
            
            while(true)
            {
                option = Console.ReadLine();

                if(option == "1" || option == "2" || option == "q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("An invalid option was selected. Valid options are:\nPlay against the bot = 1\nCheck best strategy = 2\nQuit = q");
                }

            }
        }

        public void PlayAgainstBot()
        {
            var bot = new BotPlayer();
            bot.SelectBehavior();
            var user = new Player();

            while(user.GetScore() < 10000 && bot.GetScore() < 10000)
            {
                user.PlayTurn();
                bot.PlayTurn();
            }

            if(user.GetScore() > bot.GetScore())
            {
                Console.WriteLine($"The bot won!\nFinal score:\nBot: {bot.GetScore()}\nUser: {user.GetScore()}");
            }
            else{
                Console.WriteLine($"You won!\nFinal score:\nBot: {bot.GetScore()}\nUser: {user.GetScore()}");
            }
        }

        public void CheckStrategy()
        {
            var bot = new BotPlayer();
            var testParams = new TestParameters();

            testParams.DefineParams();
            

        }

        internal string GetOption()
        {
            return option;
        }

    }
}