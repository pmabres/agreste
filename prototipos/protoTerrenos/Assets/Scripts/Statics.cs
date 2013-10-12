﻿using UnityEngine;
using System.Collections;

public static class Statics 
{
	public static GameObject CurrentTerrain;
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
