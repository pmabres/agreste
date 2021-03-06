﻿using UnityEngine;
using System.Collections;

public class GameProgression : MonoBehaviour {
	//int PawCoins=0;
	// Use this for initialization
	//Variable para guardar el High Score	
	void Awake () 
	{	
		Load();
	}
	public void Load()
	{
		if (PlayerPrefs.GetInt("MaxHealth") != 0)
		{
			Statics.MaxScore = PlayerPrefs.GetInt("MaxScore");		
			Statics.MaxHealth = PlayerPrefs.GetInt("MaxHealth");
			Statics.Agility = PlayerPrefs.GetFloat("Agility");
			Statics.Velocity = PlayerPrefs.GetFloat("Velocity");	
			Statics.Paws = PlayerPrefs.GetInt("Paws");
			Statics.CompletedMissions = PlayerPrefs.GetString("CompletedMissions");
		}
		else
		{
			Statics.MaxHealth = 2;			
		}
	}
	public void Save()
	{
		PlayerPrefs.SetInt("MaxScore",Statics.MaxScore);
		PlayerPrefs.SetInt("MaxHealth",Statics.MaxHealth);
		PlayerPrefs.SetFloat("Agility",Statics.Agility);
		PlayerPrefs.SetFloat("Velocity",Statics.Velocity);
		PlayerPrefs.SetInt ("Paws",Statics.Paws);
		PlayerPrefs.SetString("CompletedMissions",Statics.CompletedMissions);
		PlayerPrefs.Save();
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (!Statics.Paused)
		{
		}
	}
}
