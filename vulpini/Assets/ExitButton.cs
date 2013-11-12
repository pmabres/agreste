using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
public Camera cam;	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{			
		if (Input.touchCount > 0 && Statics.Menu.activeSelf==true && Statics.Paused)
		{
			if (Input.GetTouch (0).phase == TouchPhase.Began)
			{
			
			Ray cursorRay = cam.ScreenPointToRay( Input.GetTouch(0).position );
			Debug.Log(cursorRay.origin);
            RaycastHit hit;
			
	            if( collider.Raycast( cursorRay, out hit, 1000.0f))
	            {
					Application.Quit();
	            }
			}
		}
	}
}
