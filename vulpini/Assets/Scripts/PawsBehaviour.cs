using UnityEngine;
using System.Collections;

public class PawsBehaviour : MonoBehaviour {
	float time =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		time += Time.deltaTime; 
		if(time>= 1)
		{
			gameObject.GetComponent<TextMesh>().text = Statics.Paws.ToString();
			time = 0;
		}
	}
}
