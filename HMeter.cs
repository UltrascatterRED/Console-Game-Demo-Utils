using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponentLab
{
	/// <summary>
	/// A generic horizontal meter for applicable GUI elements.
	/// </summary>
	public class HMeter
	{
		protected int PosX;
		protected int PosY;
		protected int Length;
		protected ConsoleColor BorderColor;
		protected ConsoleColor BarColor;
		// private Anchor anchor | potential future attr representing positional anchor (left, right, center, etc)

		public HMeter()
		{
			PosX = 1; 
			PosY = 1;
			Length = 10;
			BorderColor = ConsoleColor.White;
			BarColor = ConsoleColor.Cyan;
		}
		public HMeter(int posX, int posY, int length, ConsoleColor borderCol = ConsoleColor.White, 
			ConsoleColor barCol = ConsoleColor.White)
		{
			PosX = posX;
			PosY = posY;
			Length = length;
			BorderColor = borderCol;
			BarColor = barCol;
		}
		/// <summary>
		/// Renders this HMeter to the screen according to initialized attributes.
		/// </summary>
		public virtual void Draw()
		{
			// top layer
			Console.SetCursorPosition(PosX, PosY);
			Console.ForegroundColor = BorderColor;
			Console.Write("┌");
			for (int i = 0; i < Length - 2; i++) { Console.Write("─"); }
			Console.Write("┐\n");
			// middle layer
			Console.SetCursorPosition(PosX, PosY + 1);
			Console.Write("│");
			Console.ForegroundColor = BarColor;
			for (int i = 0; i < Length - 2; i++) { Console.Write("|"); }
			Console.ForegroundColor = BorderColor;
			Console.Write("│\n");
			Console.SetCursorPosition(PosX, PosY + 2);
			// bottom layer
			Console.Write("└");
			for (int i = 0; i < Length - 2; i++) { Console.Write("─"); }
			Console.Write("┘\n");
			// reset console color
			Console.ForegroundColor = ConsoleColor.White;
		}
	}
}
