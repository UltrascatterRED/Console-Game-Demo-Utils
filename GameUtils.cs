using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponentLab
{
	public static class GameUtils
	{
		public static void WriteAt(string s, int x, int y)
		{
			try
			{
				Console.SetCursorPosition(x, y);
				Console.Write(s);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.Clear();
				Console.WriteLine(e.Message);
			}
		}
		public static void WriteGradual(string content, int speed = 25)
		{
			foreach(char c in content)
			{
				Console.Write(c);
				Thread.Sleep(speed);
			}
		}
	}
}
