using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	int [] MetersPerLevel = new int [10];
	// Use this for initialization
	void Start() 
	{
		Statics.CurrentLevel=1;
		MetersPerLevel[0]=500;
		MetersPerLevel[1]=1000;
		MetersPerLevel[2]=1500;
		MetersPerLevel[3]=2000;
		MetersPerLevel[4]=2500;
		MetersPerLevel[5]=3000;
		MetersPerLevel[6]=3500;
		MetersPerLevel[7]=4000;
		MetersPerLevel[8]=4500;
		MetersPerLevel[9]=5000;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
			if (Statics.CurrentLevel <= 10 && Statics.CurrentLevel >= 1)
			{			
				if (Statics.Meters >= MetersPerLevel[Statics.CurrentLevel-1])
				{
					Statics.CurrentLevel++;
				}
			}
		}
	}
}
