using UnityEngine;
using System.Collections;

public static class Constants {
	public const string RESOURCES_FOLDER = "Prefabs/";
	public const string TAG_ENEMIES = "Enemies";
	public const string TAG_TERRAIN = "Terrain";
	public const string TAG_PLAYER = "Player";
	public const string TAG_MAIN = "Main";	
	public const string NAME_TREES = "Tree";	
	public const string TAG_GAMEOVER = "GameOver";
	public const string TAG_MENU = "Menu";
	public const string TAG_HUD = "HUD";	
	public const int WIDESCREEN_IDEAL_WIDTH = 475;
	public const float TOUCH_SCREEN_WIDTH_PROPORTION = 0.21f; 
	public const float TOUCH_SCREEN_HEIGHT_PROPORTION = 0.185f;
	
	public enum EnemiesNames
	{
		Min = 1,
		HunterA = 1,
		Max = 1
	}
}
