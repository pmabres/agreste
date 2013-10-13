using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Main : MonoBehaviour 
{
	TerrainList terrainList;
	// Use this for initialization
	void Start () 
	{		
		Statics.TreesPerTerrain=30;
		terrainList = new TerrainList();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Statics.AccelerometerActive = false;
		Statics.Paused = true;
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
			
		}
	}
}