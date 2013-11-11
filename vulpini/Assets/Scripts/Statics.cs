using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Statics 
{
	public static GameObject Player;
	public static GameObject CurrentTerrain;
	public static GameObject Menu;
	public static GameObject GameOver;
	public static GameObject HUD;
	public static GameObject Hit;
	public static GameObject pre;
	public static GameObject pre1;
	public static GameObject pre2;
	public static GameObject pre3;
	public static GameObject pre4;
	public static GameObject DescP;
	
	
	
	public static bool RestartGame=false;
	public static int TreesPerTerrain=20;
	public static int GrassPerTerrain=100;
	public static TerrainList Terrains;
	public static bool AccelerometerActive=false;
	public static bool Paused=false;	
	public static int Meters=0;
	public static int CurrentLevel=0;
	public static float TimerSpawn = 2;
	//Variable para guardar el High Score
	public static int MaxScore;
	//Guarda las patitas que tiene el personaje
	public static int Paws;
	//Variables del Personaje
	public static int MaxHealth;
	public static float Agility;
	public static float Velocity;	
	public static float MaxTimeSpeed = 8;
	public static int CountPowers=0;
	public static int TimeAttack=5;
	public static int TimeFree=10;
	public static bool FreeRoad=false;
	
	public static string CompletedMissions;
	public static List<Misiones> lstMissions = new List<Misiones>();	
	public static int MetersOneHit=0;
	public static int MetersSide=0;
	public static int SmashedEnemies=0;
	public static int PowerUpsHitted=0;
	
	public static GameObject Instantiate(string tag)
	{		
		return MonoBehaviour.Instantiate(Resources.Load(Constants.RESOURCES_FOLDER+tag)) as GameObject;
	}
	public static GameObject Instantiate(string tag,Vector3 position, Transform Parent)
	{						
		GameObject tmp = Instantiate(tag);
		tmp.transform.position = position;
		tmp.transform.parent = Parent;
		return tmp;
		
	}
	public static GameObject Instantiate(string tag,Vector3 position, Transform Parent, string Name)
	{				
		GameObject tmp = Instantiate(tag,position,Parent);		
		tmp.name = Name;
		return tmp;		
	}	
	
}