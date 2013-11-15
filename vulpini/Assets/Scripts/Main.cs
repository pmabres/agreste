using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour 
{
	//TerrainList terrainList;
	// Use this for initialization
	void Awake()
	{
		Statics.Terrains = new TerrainList();
		Statics.Menu = GameObject.FindGameObjectWithTag(Constants.TAG_MENU);
		Statics.GameOver = GameObject.FindGameObjectWithTag(Constants.TAG_GAMEOVER);
		Statics.HUD = GameObject.FindGameObjectWithTag(Constants.TAG_HUD);
		Statics.Hit = GameObject.FindGameObjectWithTag("RedScreen");
		Statics.GameOver.SetActive(false);
		Statics.Hit.SetActive(false);
		Statics.Paw = GameObject.FindGameObjectWithTag(Constants.TAG_PAWS);
		Statics.MetersOneHit=0;
		Statics.MetersSide=0;
	 	Statics.SmashedEnemies=0;
	 	Statics.PowerUpsHitted=0;
		Statics.lstMissions.Clear();
		Statics.PreC = GameObject.FindGameObjectWithTag(Constants.TAG_PREC);
		Statics.Titulo = GameObject.FindGameObjectWithTag(Constants.TAG_TITULO);
	}
	void Start () 
	{	
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Statics.AccelerometerActive = false;
		Statics.Paused = true;
		Statics.Terrains.gTerrains.transform.parent = gameObject.transform;
		Statics.Paw.GetComponent<TextMesh>().text = Statics.Paws.ToString();
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if (!Statics.Paused)
		{		
			
		}
		
	}
	void FixedUpdate()
	{
		if (!Statics.Paused)
		{		
			if (Statics.Player.GetComponent<PlayerBehaviour>().HitPoints <= 0)
			{
				Statics.Paused = true;				
				Statics.GameOver.SetActive(true);
				Statics.HUD.SetActive(false);
				Statics.Menu.SetActive(false);
				gameObject.GetComponent<GameProgression>().Save();
				Statics.Titulo.SetActive(false);
			}
		}
		if (Statics.RestartGame)
		{
			gameObject.GetComponent<GameProgression>().Save();
			Statics.RestartGame = false;
			Application.LoadLevel(Application.loadedLevelName);			
			Statics.Paused = true;
			Statics.GameOver.SetActive(false);
			Statics.HUD.SetActive(true);
			Statics.Menu.SetActive(true);
			Statics.PreC.SetActive(true);
			Statics.Titulo.SetActive(true);
		}	
	}
}