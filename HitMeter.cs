using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponentLab
{
	/// <summary>
	/// Specialized meter for evaulating timed hits from the player.
	/// </summary>
	public class HitMeter : HMeter
	{
		private int Speed; // speed of HitTest animation (number of frame changes per second)
		private int HitLocation; // zero-indexed location for player to hit
		private ConsoleColor HitLocColor;

		public HitMeter(int posX, int posY, int length, int speed, int hitLocation, 
			ConsoleColor borderCol = ConsoleColor.White, ConsoleColor barCol = ConsoleColor.White, 
			ConsoleColor hitLocColor = ConsoleColor.White) 
			: base(posX, posY, length, borderCol, barCol)
		{
			Speed = speed;
			if (hitLocation >= 0 && hitLocation <= Length - 3) HitLocation = hitLocation;
			else HitLocation = (Length - 2)/2;
			HitLocColor = hitLocColor;
		}
		public override void Draw()
		{
			// top layer
			Console.SetCursorPosition(PosX, PosY);
			Console.ForegroundColor = BorderColor;
			Console.Write("┌");
			for (int i = 0; i < Length - 2; i++) 
			{ 
				if(Console.CursorLeft == HitLocation + 2)
				{
					Console.ForegroundColor = HitLocColor;
					Console.Write("┼");
					Console.ForegroundColor = BorderColor;
				}
				else
				{
					Console.Write("─");
				}
			}
			Console.Write("┐\n");
			// middle layer
			Console.SetCursorPosition(PosX, PosY + 1);
			Console.Write("│");
			Console.ForegroundColor = BarColor;
			for (int i = 0; i < Length - 2; i++) { Console.Write(" "); }
			Console.ForegroundColor = BorderColor;
			Console.Write("│\n");
			Console.SetCursorPosition(PosX, PosY + 2);
			// bottom layer
			Console.Write("└");
			for (int i = 0; i < Length - 2; i++) 
			{
				if (Console.CursorLeft == HitLocation + 2)
				{
					Console.ForegroundColor = HitLocColor;
					Console.Write("┼");
					Console.ForegroundColor = BorderColor;
				}
				else
				{
					Console.Write("─");
				}
			}
			Console.Write("┘\n");
			// reset console color
			Console.ForegroundColor = ConsoleColor.White;
		}
		/// <summary>
		/// Render an animated bar and a static bar indicating the hit location for a successful blow.
		/// </summary>
		public void HitTest()
		{
			Console.CursorVisible = false;
			int frameTime = 1000 / Speed; // time per frame in ms
			ConsoleKeyInfo playerKeyInfo;
			Console.ForegroundColor = BarColor;
			// TODO: refactor below to use GameUtils.WriteAt() method
			do
			{
				while (!Console.KeyAvailable)
				{
					for (int i = 0; i < Length - 3; i++)
					{
						if (i > 0) Console.Write(" ");
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Console.Write("|");
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Thread.Sleep(frameTime);
					}
					for (int i = Length - 3; i > 0; i--)
					{
						if (i < Length - 2) Console.Write(" ");
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Console.Write("|");
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Thread.Sleep(frameTime);
					}
				}
			}
			while (Console.ReadKey(true).Key != ConsoleKey.E);
		}
	}
}
