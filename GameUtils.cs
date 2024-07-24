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
		/// <summary>
		/// Writes a string to the screen with delay between each character, creating an RPG-style
		/// display effect. Speed can be configured.
		/// </summary>
		/// <param name="content"></param>
		/// <param name="speed"></param>
		public static void WriteGradual(string content, int speed = 25)
		{
			foreach(char c in content)
			{
				Console.Write(c);
				Thread.Sleep(speed);
			}
		}
		/// <summary>
		/// Writes a single character to the screen, followed by a delay. Speed can be configured.
		/// </summary>
		/// <param name="c"></param>
		/// <param name="speed"></param>
		public static void WriteGradual(char c, int speed = 25)
		{
			Console.Write(c);
			Thread.Sleep(speed);
		}
	}
}
