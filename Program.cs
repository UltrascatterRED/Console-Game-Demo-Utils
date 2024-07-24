namespace GameComponentLab
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DisplayBox test = new DisplayBox(20, 5, 0, 0, true, "This is an example message that is a bit longer");
			test.DrawBorder();
            test.DrawContentGradual();
            Console.ReadLine();
            test.ClearContent();
            test.SetContent("Bananas are tasty and we should all strive to eat more of them. Wouldn't you agree?");
            test.DrawContentGradual();
            Console.ReadLine();
            GameUtils.WriteGradual("Hello! This is an example message to \ndemonstrate the fancier display\neffect of gradual text letter \nby letter.", 10);
            Console.ReadLine();
		}
	}
}
