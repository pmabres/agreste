using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {
	bool runUp= true;
	bool runDown = false;
	public float Yup = 0.02f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!Statics.Paused)
		{
			if(transform.localPosition.y <= 1 && runUp) 
			{
				transform.localPosition += new Vector3 (0, Yup, 0);
			}
			if(transform.localPosition.y >= 0.15 && runDown)
			{
				transform.localPosition -= new Vector3 (0, Yup, 0);
			}
			
			if(transform.localPosition.y >= 1)
			{
				runUp = false;
				runDown = true;
			}
			
			if(transform.localPosition.y <= 0.15)
			{
				runUp = true;
				runDown = false;
			}
		}
	}
}
