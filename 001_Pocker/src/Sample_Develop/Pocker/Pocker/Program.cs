namespace Pocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainLogic();
        }

        static void MainLogic()
        {
            Console.WriteLine("********************************");
            Console.WriteLine("Pocker Game Start !!");
            Console.WriteLine("********************************");
            Console.WriteLine("");

            string userName = getUserName();
            Console.WriteLine("こんにちは、" + userName + "さん！");

            while (true) {
               
                Console.WriteLine("");
                Console.WriteLine("*** START NEW GAME !! ***");
                
                PokerGame game = new PokerGame(userName);
                game.StartGame();


                if (isExit()) break;
            }




            Console.WriteLine("");
            Console.WriteLine("********************************");
            Console.WriteLine("Thanks for playing! See you later, " + userName + " !!");
            Console.WriteLine("********************************");


        }

        private static string getUserName()
        {
            while (true)
            {
                Console.WriteLine("あなたの名前を入力してください。:");

                string? userName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    return userName;
                }
            }
        }

        private static bool isExit()
        {
            Console.WriteLine("ゲームを終了しますか？[y or yes]");
            string? userInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(userInput))
            {
                // 入力を小文字に変換して比較
                string loweredInput = userInput.ToLower().Trim();

                // Y, y, Yes, yes のいずれかの場合は true を返す
                if (loweredInput == "y" || loweredInput == "yes")
                {
                    return true;
                }
            }

            return false;

        }

    }
}
