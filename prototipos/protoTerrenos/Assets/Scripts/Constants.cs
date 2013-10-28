﻿using UnityEngine;
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
	public const string TAG_POWER = "Powers";
	public const int MAX_POWER_VIEW = 5;
	
	
	public const int WIDESCREEN_IDEAL_WIDTH = 475;
	public const float TOUCH_SCREEN_WIDTH_PROPORTION = 0.21f; 
	public const float TOUCH_SCREEN_HEIGHT_PROPORTION = 0.185f;
	
	public enum EnemiesNames
	{
		Min = 0,
		HunterA = 0,
		HunterB= 1,
		HunterC= 2,
		HunterD= 3,
		HunterE=4,
		Max = 5
	}
	
	public enum PowerNames
	{
		Min=0,
		Heal= 0,
		Speed= 1,
		Attack= 2,
		Free= 3,
		Max= 4
	}
}
