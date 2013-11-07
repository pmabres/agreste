using UnityEngine;
using System.Collections;

public class MetersCounter : MonoBehaviour {	
	// Use this for initialization
	void Start () {
		//gameObject.transform.position = new Vector3(Screen.width/10,gameObject.transform.position.y,gameObject.transform.position.z);
		//gameObject.transform.localPosition = new Vector3(Screen.width / 10,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
		//Debug.Log(Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)));		
		//Debug.Log(Camera.main.ScreenToViewportPoint(new Vector3(Screen.width,0,0)));
		//Debug.Log(Screen.width);
		//Debug.Log(gameObject.transform.position.x);
		
	}	
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{			
			gameObject.GetComponent<TextMesh>().text = "Metros: " + Statics.Meters;
			if(gameObject.GetComponent<TextMesh>().CompareTag("HighScore"))
			{
				gameObject.GetComponent<TextMesh>().text = "High Score: " + Statics.MaxScore;
			}
		}
	}
}
