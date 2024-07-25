namespace GameComponentLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Timer test = new Timer(15,'*',15,1,1,ConsoleColor.Yellow,ConsoleColor.Red);
			test.Run();
            Console.ReadLine();
		}
	}
}
