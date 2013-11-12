using UnityEngine;
using System.Collections;

public class PreAdq4 : MonoBehaviour {
	public Camera cam;	
	Ray cursorRay;
	RaycastHit hit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		 	if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				Debug.Log("EntaP4");
				cursorRay = cam.ScreenPointToRay(Input.GetTouch(0).position);
				if(collider.Raycast(cursorRay,out hit, 1000.0f))
				{
					Debug.Log("sPRE4");		
					Statics.Player.GetComponent<Avanzar>().Speed=true;
				}
				Statics.Pre1.SetActive(false);
				Statics.Pre2.SetActive(false);
				Statics.Pre3.SetActive(false);
				Statics.Pre4.SetActive(false);
			}
	}
}
