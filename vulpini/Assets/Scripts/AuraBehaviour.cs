using UnityEngine;
using System.Collections;

public class AuraBehaviour : MonoBehaviour {
	// Use this for initialization
	public float speed=0;
	private Color c;
	private float end=0;
	private float time=0.2f;
	private bool activated=false;
	private bool fire=false;
	
	void Awake()
	{			
		c = gameObject.renderer.material.color;
		c.a = 0;
		gameObject.renderer.material.color = c;
		activated = false;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 	
	{
		if (!Statics.Paused)
		{
			gameObject.transform.rotation = Quaternion.identity;
			if (activated) 
			{
				end = 1.2f;
				time = speed;
				if (c.a >= 1)
				{
					fire=true;
				}
			}
			else
			{
				time = 2;
				end = 0;
			}
			
			//if (c.a >= 0.1f && c.a <= 1)
			//{
				// la funcion lerp sirve para hacer transiciones de numeros de forma gradual
			c.a = Mathf.Lerp(gameObject.renderer.material.color.a,end,Time.deltaTime*time);
			gameObject.renderer.material.color = c;
			//}			
		}
	}
	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject == Statics.Player)
		{						
			activated = true;
		}
	}
	void OnTriggerStay(Collider collider)
	{
		if (activated && collider.gameObject == Statics.Player && fire)
		{
			gameObject.transform.parent.GetComponent<EnemyBehaviour>().Hit();			
			activated = false;
			fire = false;
		}
	}
	void OnTriggerExit (Collider collider)
	{
		if (collider.gameObject == Statics.Player)
		{
			activated = false;
		}
	}
}
