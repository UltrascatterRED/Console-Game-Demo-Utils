namespace GameComponentLab
{
	public class DisplayBox
	{
		// The available space for content display is always of [SizeX - 2, SizeY - 2] due to the presence
		// of a border or padding
		private int SizeX;
		private int SizeY;
		private int PosX;
		private int PosY;
		// Whether or not box has a decorative border. If false, box has whitespace padding instead.
		private bool Bordered;
		//private Style style;
		private string? Content;

		// getters
		public int GetSizeX()
		{
			return SizeX;
		}
		public int GetSizeY()
		{
			return SizeY;
		}
		public int GetPosX()
		{
			return PosX;
		}
		public int GetPosY()
		{
			return PosY;
		}
		public bool GetBordered()
		{
			return Bordered;
		}
		public string GetContent()
		{
			return Content;
		}
		public int GetCapacity()
		{
			return (SizeX - 2) * (SizeY - 2);
		}
		// setters
		private void SetSizeX(int sizeX)
		{
			SizeX = sizeX;
		}
		private void SetSizeY(int sizeY)
		{
			SizeY = sizeY;
		}
		private void SetPosX(int posX)
		{
			PosX = posX;
		}
		private void SetPosY(int posY)
		{
			PosY = posY;
		}
		private void SetBordered(bool bordered)
		{
			Bordered = bordered;
		}
		public void SetContent(string content)
		{
			if(content == null) return;
			Content = content;
		}

		public DisplayBox()
		{
			SetSizeX(10);
			SetSizeY(10);
			SetPosX(0);
			SetPosY(0);
			SetBordered(false);
			SetContent("Sample Text");
		}
		public DisplayBox(int sizeX, int sizeY, int posX, int posY, bool bordered, string? content)
		{
			SetSizeX(sizeX);
			SetSizeY(sizeY);
			SetPosX(posX);
			SetPosY(posY);
			SetBordered(bordered);
			SetContent(content);
		}
		/// <summary>
		/// Draws the border of this DisplayBox on the screen.
		/// </summary>
		public void DrawBorder()
		{
			if (Bordered)
			{
				Console.SetCursorPosition(PosX, PosY);
				for (int i = 0; i < SizeY; i++)
				{
					Console.SetCursorPosition(PosX, PosY + i);
					for (int j = 0; j < SizeX; j++)
					{
						if (i == 0)
						{
							if (j == 0) Console.Write('╔');
							else if (j == SizeX - 1) Console.Write('╗');
							else Console.Write('═');
						}
						else if (i == SizeY - 1)
						{
							if (j == 0) Console.Write('╚');
							else if (j == SizeX - 1) Console.Write('╝');
							else Console.Write('═');
						}
						else if (j == 0) Console.Write('║');
						else if (j == SizeX - 1) Console.Write('║');
						else Console.Write(' ');
					}
				}
			}
			else
			{
				for (int i = 0; i < SizeY; i++)
				{
					Console.SetCursorPosition(PosX, PosY + i);
					for (int j = 0; j < SizeX; j++)
					{
						Console.Write(' ');
					}
				}
			}
		}
		/// <summary>
		/// Draws this DisplayBox's current content to the screen. Content exceeding the bounds of the DisplayBox is truncated
		/// to fit within the box.
		/// </summary>
		public void DrawContent()
		{
			if (Content == null) return;
			int currentY;
			int charsWritten = 0;
			bool newLine = false;

			Console.SetCursorPosition(PosX + 1, PosY + 1);
			currentY = PosY + 1;
			foreach (char c in Content)
			{
				if(newLine && c == ' ')
				{
					continue;
				}
				newLine = false; // reset newLine
				if (charsWritten >= GetCapacity()) break;
				Console.Write(c);
				charsWritten++;
				if (Console.GetCursorPosition().Left > SizeX - 2)
				{
					currentY++;
					Console.SetCursorPosition(PosX + 1, currentY);
					newLine = true;
				}
			}
			Console.SetCursorPosition(0, SizeY);
		}
		/// <summary>
		/// Draws this DisplayBox's current content to the screen with a delay between characters. <br/>
		/// Content exceeding the bounds of the DisplayBox is truncated to fit within the box.
		/// </summary>
		public void DrawContentGradual()
		{
			if (Content == null) return;
			int currentY;
			int charsWritten = 0;
			bool newLine = false;

			Console.SetCursorPosition(PosX + 1, PosY + 1);
			currentY = PosY + 1;
			foreach (char c in Content)
			{
				if (newLine && c == ' ')
				{
					continue;
				}
				newLine = false; // reset newLine
				if (charsWritten >= GetCapacity()) break;
				GameUtils.WriteGradual(c);
				charsWritten++;
				if (Console.GetCursorPosition().Left > SizeX - 2)
				{
					currentY++;
					Console.SetCursorPosition(PosX + 1, currentY);
					newLine = true;
				}
			}
			Console.SetCursorPosition(0, SizeY);
		}
		/// <summary>
		/// Resets the displayed content to be empty. DOES NOT affect the value of the Content field.
		/// </summary>
		public void ClearContent()
		{
			int currentY;
			bool newLine = false;

			Console.SetCursorPosition(PosX + 1, PosY + 1);
			for(int i = 0; i < SizeY - 2; i++)
			{
				Console.SetCursorPosition(PosX + 1, PosY + 1 + i);
				for (int j = 0; j < SizeX - 2; j++)
				{
					Console.Write(' ');
				}
			}
			Console.SetCursorPosition(0, SizeY);
		}
		public void DrawAll()
		{
			DrawBorder();
			DrawContent();
		}
		
	}
}
