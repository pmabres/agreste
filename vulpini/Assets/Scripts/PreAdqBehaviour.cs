using UnityEngine;
using System.Collections;

public class PreAdqBehaviour : MonoBehaviour {
	public Camera cam;	
	public GameObject pre1;
	public GameObject pre2;
	public GameObject pre3;
	public GameObject pre4;
	Ray cursorRay;
	RaycastHit hit;
	
	// Use this for initialization
	void Start () {
		Statics.Pre1.SetActive(false);
		Statics.Pre2.SetActive(false);
		Statics.Pre3.SetActive(false);
		Statics.Pre4.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && Statics.Menu.activeSelf==true && Statics.Paused)
		{
			if (Input.GetTouch (0).phase == TouchPhase.Began)
			{
				cursorRay = cam.ScreenPointToRay(Input.GetTouch(0).position);			
	            if( collider.Raycast( cursorRay, out hit, 1000.0f))
	            {
					Statics.Pre1.SetActive(true);
					Statics.Pre2.SetActive(true);
					Statics.Pre3.SetActive(true);
					Statics.Pre4.SetActive(true);
	            }
			}
			
		    else if(Input.GetTouch(0).phase == TouchPhase.Ended)
			{
				cursorRay = cam.ScreenPointToRay(Input.GetTouch(0).position);
				if(pre1.collider.Raycast(cursorRay,out hit, 1000.0f))
				{
					Statics.Player.GetComponent<Avanzar>().Speed=true;
				}
				else if(pre2.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					Debug.Log("hoasd");
				}
				else if(pre3.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					Debug.Log("hoasd");
				}
				else if(pre4.collider.Raycast(cursorRay, out hit, 1000.0f))
				{
					Debug.Log("hoasd");
				}
				Statics.Pre1.SetActive(false);
				Statics.Pre2.SetActive(false);
				Statics.Pre3.SetActive(false);
				Statics.Pre4.SetActive(false);
			}
		}
	}
}
