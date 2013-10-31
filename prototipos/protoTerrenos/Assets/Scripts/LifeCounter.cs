using UnityEngine;
using System.Collections;

public class LifeCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{			
			gameObject.GetComponent<TextMesh>().text = "Vida: " + Mathf.FloorToInt(Statics.Player.GetComponent<PlayerBehaviour>().HitPoints);
			
			if(Mathf.FloorToInt(Statics.Player.GetComponent<PlayerBehaviour>().HitPoints)<=0)
			{
				if(Statics.Meters > Statics.MaxScore)
				{
					Statics.MaxScore = Statics.Meters;
					PlayerPrefs.SetFloat("MaxScore",Statics.Meters);
				}
			}
		}
	}
}
