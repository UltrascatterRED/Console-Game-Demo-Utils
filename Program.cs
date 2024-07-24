namespace GameComponentLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DisplayBox test = new DisplayBox(20, 5, 0, 0, true, "This is an example message that is a bit longer");
			test.DrawAll();
			Console.ReadLine();
			GameUtils.WriteGradual("Hello! This is an example message to \ndemonstrate the fancier display\neffect of gradual text letter \nby letter.", 10);
			Console.ReadLine();
		}
	}
}
