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
		// TODO: refactor to return bool indicating hit success
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
					Console.SetCursorPosition(PosX + 1, PosY + 1);
					for (int i = 0; i < Length - 3; i++)
					{
						Console.Write(" ");
						GameUtils.WriteAt("|", PosX + i + 1, PosY + 1);
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Thread.Sleep(frameTime);
						if (Console.KeyAvailable) break; //Console.In.ToString().Contains('e') | NOTE: alter how an 'E' press is checked
					}
					if (Console.KeyAvailable) break; 
					for (int i = Length - 3; i > 0; i--)
					{
						Console.Write(" ");
						GameUtils.WriteAt("|", PosX + i + 1, PosY + 1);
						Console.SetCursorPosition(PosX + i + 1, PosY + 1);
						Thread.Sleep(frameTime);
						if(i == 1) Console.Write(" "); // fixes visual bug w/ looping animation
						if (Console.KeyAvailable) break;
					}
				}
			}
			while (Console.ReadKey(true).Key != ConsoleKey.E); 
			// reset environment variables
			Console.ForegroundColor = ConsoleColor.White;
			Console.CursorVisible = true;

			// check if player landed a hit
			if(Console.CursorLeft == HitLocation + 2)
			{
				Console.SetCursorPosition(PosX, PosY + 3);
				Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HIT");
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Console.SetCursorPosition(PosX, PosY + 3);
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("MISS");
				Console.ForegroundColor = ConsoleColor.White;
			}
		}
	}
}
