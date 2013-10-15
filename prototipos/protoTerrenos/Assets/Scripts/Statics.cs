using UnityEngine;
using System.Collections;

public static class Statics 
{
	public static GameObject Player;
	public static GameObject CurrentTerrain;
	public static GameObject Menu;
	public static GameObject GameOver;
	public static GameObject HUD;
	public static bool RestartGame=false;
	public static int TreesPerTerrain=30;
	public static TerrainList Terrains;
	public static bool AccelerometerActive=false;
	public static bool Paused=false;	
	public static float Meters=0;
	public static int CurrentLevel=0;	
	public static GameObject Instantiate(string tag)
	{		
		return MonoBehaviour.Instantiate(Resources.Load(Constants.RESOURCES_FOLDER+tag)) as GameObject;
	}
	public static GameObject Instantiate(string tag,Vector3 position, Transform Parent)
	{				
		GameObject tmp = MonoBehaviour.Instantiate (Resources.Load(Constants.RESOURCES_FOLDER+tag)) as GameObject;
		tmp.transform.position = position;
		tmp.transform.parent = Parent;
		return tmp;
		
	}	
	
}