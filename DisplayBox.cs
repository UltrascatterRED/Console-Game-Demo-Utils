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
		public void DrawContent()
		{
			if (Content == null) return;
			int currentY;
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
				Console.Write(c);
				if (Console.GetCursorPosition().Left > SizeX - 2)
				{
					currentY++;
					Console.SetCursorPosition(PosX + 1, currentY);
					newLine = true;
				}
			}
			Console.SetCursorPosition(0, SizeY);
		}
		public void DrawAll()
		{
			DrawBorder();
			DrawContent();
		}
		//public override string ToString // may be unnecessary
	}
}
