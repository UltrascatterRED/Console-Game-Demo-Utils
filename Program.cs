namespace GameComponentLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//HMeter test = new(3, 5, 20, ConsoleColor.DarkGreen, ConsoleColor.Red);
			//test.Draw();
			HitMeter testHM = new(1, 1, 20, 16, 5, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Red);
			testHM.Draw();
			testHM.HitTest();
		}
	}
}
