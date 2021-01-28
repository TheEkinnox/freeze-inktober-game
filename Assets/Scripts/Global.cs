using System;

public static class Inputs
{
	public static string Freeze = "Jump";
	public static string Exit = "Cancel";
}

public static class AnimatorVars
{
	public static string PlayerState = "state";
}

public static class Scenes
{
	public static string Game = "Game";
	public static string MainMenu = "Menu";
}

public static class Global
{
	private static Random _rand = new Random();

	public static int RandomInt(int min, int max)
		=> Global._rand.Next(min, max+1);
	public static int RandomInt(int max)
		=> Global._rand.Next(0, max+1);
}