using UnityEngine;
using System.Collections;

public class AccelerometerButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{			
		if (Input.touchCount > 0 && Statics.Menu.activeSelf==true)
		{			
			float x1 = Camera.main.ScreenToWorldPoint(gameObject.transform.position - gameObject.transform.localScale /2).x -(float)25;
			float x2 = Camera.main.ScreenToWorldPoint(gameObject.transform.position + gameObject.transform.localScale /2).x +(float)25;
			float y1 = Camera.main.ScreenToWorldPoint(gameObject.transform.position - gameObject.transform.localScale /2).y -(float)25;			
			float y2 = Camera.main.ScreenToWorldPoint(gameObject.transform.position + gameObject.transform.localScale /2).y +(float)25;
			Debug.Log(x1);
			Debug.Log(Input.GetTouch(0).position.x);
			Debug.Break();
			if (x1 <= Input.GetTouch(0).position.x && x2 >= Input.GetTouch(0).position.x &&
				y1 <= Input.GetTouch(0).position.y && y2 >= Input.GetTouch(0).position.y)
			{				
				
				Statics.AccelerometerActive = !Statics.AccelerometerActive;
				if (Statics.AccelerometerActive)
				{
					gameObject.GetComponent<TextMesh>().color = Color.white;
				}
				else
				{
					gameObject.GetComponent<TextMesh>().color = Color.grey;
				}				
			}
		}
	}
}
