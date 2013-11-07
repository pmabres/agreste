﻿using UnityEngine;
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
	}
	void Start () 
	{		
		
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Statics.AccelerometerActive = false;
		Statics.Paused = true;
		Statics.Terrains.gTerrains.transform.parent = gameObject.transform;
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
		}	
	}
}