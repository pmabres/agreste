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
	public static int TreesPerTerrain=35;
	public static TerrainList Terrains;
	public static bool AccelerometerActive=false;
	public static bool Paused=false;	
	public static float Meters=0;
	public static int CurrentLevel=0;
	//Variable para guardar el High Score
	public static float MaxScore= PlayerPrefs.GetFloat("MaxScore");
	
	//Variables del Personaje
	public static int MaxHealth = PlayerPrefs.GetInt("Health")==0?2:PlayerPrefs.GetInt("Health");
	public static float Agility = PlayerPrefs.GetFloat("Agility");
	public static float Velocity = PlayerPrefs.GetFloat("Velocity");
	public static int Level = PlayerPrefs.GetInt("Level")+1;
	public static float MaxTimeSpeed = 8;
	public static int CountPowers=0;
	public static int TimeAttack=5;
	public static int TimeFree=10;
	public static bool FreeRoad=false;
	
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
	public static GameObject InstantiatePower(string tag,Vector3 position, Transform Parent, string Name)
	{				
		GameObject tmp = MonoBehaviour.Instantiate (Resources.Load(Constants.RESOURCES_FOLDER+tag)) as GameObject;
		tmp.transform.position = position;
		tmp.transform.parent = Parent;
		tmp.name = Name;
		return tmp;
		
	}	
	
}