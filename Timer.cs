using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public class Timer
{
	private double Duration; // seconds
	private char DisplayChar = '|';
	private int DisplayLength;
	private int PosX;
	private int PosY;
	private ConsoleColor BaseColor;
	private ConsoleColor TickDownColor;
	private bool Stopped = true;
	private bool Finished = false; // whether or not timer is at 0

	// getters
	public double GetDuration()
	{
		return Duration;
	}
	public char GetDisplayChar()
	{
		return DisplayChar;
	}
	public int GetDisplayLength()
	{
		return DisplayLength;
	}
	public int GetPosX()
	{
		return PosX;
	}
	public int GetPosY()
	{
		return PosY;
	}
	public bool GetStopped()
	{
		return Stopped;
	}
	public bool GetFinished()
	{
		return Finished;
	}
	// setters
	private void SetDuration(double duration)
	{
		Duration = duration;
	}
	private void SetDisplayChar(char displayChar)
	{
		DisplayChar = displayChar;
	}
	private void SetDisplayLength(int displayLength)
	{
		DisplayLength = displayLength;
	}
	private void SetPosX(int posX)
	{
		PosX = posX;
	}
	private void SetPosY(int posY)
	{
		PosY = posY;
	}
	private void SetBaseColor(ConsoleColor baseColor)
	{
		BaseColor = baseColor;
	}
	private void SetTickDownColor(ConsoleColor tickDownColor)
	{
		TickDownColor = tickDownColor;
	}
	public Timer()
	{
		SetDuration(10);
		SetDisplayChar('|');
		SetDisplayLength(10);
		SetPosX(1);
		SetPosY(1);
		SetBaseColor(ConsoleColor.White);
		SetTickDownColor(ConsoleColor.Black);
	}
	public Timer(double duration, char displayChar, int displayLength, int posX, int posY, 
		ConsoleColor baseColor, ConsoleColor tickDownColor)
	{
		SetDuration(duration);
		SetDisplayChar(displayChar);
		SetDisplayLength(displayLength);
		SetPosX(posX);
		SetPosY(posY);
		SetBaseColor(baseColor);
		SetTickDownColor(tickDownColor);
	}
	/// <summary>
	/// Starts this timer and runs to completion exactly once.
	/// </summary>
	public void Run()
	{
		int incrementDuration = (int)(Duration / DisplayLength * 1000); // duration per display bar in milliseconds
		for(int i = 0; i <= DisplayLength; i++)
		{
			if (Stopped)
			{
				
			}
			Draw(i);
			Thread.Sleep(incrementDuration);
		}
		Finished = true;
	}
	/// <summary>
	/// Starts this timer and loops continuously.
	/// </summary>
	// DEV NOTE: must have a means of breaking infinite loop
	public void RunContinuous()
	{

	}
	/// <summary>
	/// Stops this timer in its current state.
	/// </summary>
	public void Stop()
	{

	}
	/// <summary>
	/// Resets this timer.
	/// </summary>
	public void Reset()
	{

	}
	/// <summary>
	/// Draws this timer's screen display according to the related fields.<br/>
	/// Param 'progress' specifies the number of display bars that should show <br/>
	/// as depleted (cannot exceed DisplayLength).
	/// </summary>
	/// <paramref name="progress"/>
	public void Draw(int progress = 0)
	{
		Console.SetCursorPosition(PosX, PosY);
		ConsoleColor origForeground = Console.ForegroundColor; // temporarily store initial foreground color
		Console.ForegroundColor = BaseColor;
		for(int i = DisplayLength; i > 0; i--)
		{
			if(i <= progress)
			{
				Console.ForegroundColor = TickDownColor;
			}
			Console.Write(DisplayChar);
		}
		Console.ForegroundColor = origForeground; // reset foreground color to original value
	}
}
