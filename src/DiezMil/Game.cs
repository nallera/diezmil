using System;

namespace DiezMil
{
    public class Game
    {
        private string option;
        private Player user;
        private BotPlayer bot;
        private TestParameters testParams;

        public Game()
        {
            option = "";
            user = new Player();
            bot = new BotPlayer();
            testParams = new TestParameters();
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
        
        private void ShowScores()
        {
            Console.WriteLine($"User score: {user.GetScore()}");
        }

        public void PlayAgainstBot()
        {
            bot.SelectBehavior();

            while(user.GetScore() < 10000 && bot.GetScore() < 10000)
            {
                user.PlayTurn();
                ShowScores();
                //bot.PlayTurn();
                //Console.WriteLine("End of turn.");
                //ShowScores();
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
            testParams.DefineParams();

        }

        internal string GetOption()
        {
            return option;
        }

    }
}