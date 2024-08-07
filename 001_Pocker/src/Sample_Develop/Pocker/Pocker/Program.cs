namespace Pocker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            MainLogic();
            Console.WriteLine("End  , World!");
        }

        static void MainLogic()
        {
            // Todo:本来入力で受け取る ユーザーの名前
            string userName = "Yamada Taro";

            PokerGame game = new PokerGame(userName);
            game.StartGame();

        }

    }
}
