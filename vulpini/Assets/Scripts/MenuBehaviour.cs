using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {
		
	public int State = 0;
	// Use this for initialization
	void Start () 
	{		
		Statics.pre1.SetActive(false);
		Statics.pre2.SetActive(false);
		Statics.pre3.SetActive(false);
		Statics.pre4.SetActive(false);
		Statics.DescP.SetActive(false);
	}	
	// Update is called once per frame
	void FixedUpdate () 
	{
			
		if (Input.touchCount>0 && Statics.Paused)
		{
			if (Input.GetTouch(0).position.x>Screen.width*Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
				Input.GetTouch(0).position.x<Screen.width - Screen.width * Constants.TOUCH_SCREEN_WIDTH_PROPORTION &&
				Input.GetTouch(0).position.y>Screen.height*Constants.TOUCH_SCREEN_HEIGHT_PROPORTION &&
				Input.GetTouch(0).position.y<Screen.height - Screen.height * Constants.TOUCH_SCREEN_HEIGHT_PROPORTION)
			{		
				if (Statics.GameOver.activeSelf)
				{
					Statics.RestartGame=true;
				}
				Statics.Paused = false;			
				Statics.GameOver.SetActive(false);
				Statics.Menu.SetActive(false);
				Statics.HUD.SetActive(true);
			}
		}
		//MOUSE
		else if (Input.GetMouseButtonDown(0) && Statics.Paused)
		{	
			

			if (Input.mousePosition.x >= 800 && Input.mousePosition.x <= 880
				&& Input.mousePosition.y >= 39 && Input.mousePosition.y <= 117 && State==0){
				Statics.pre1.SetActive(true);
				Statics.pre2.SetActive(true);
				Statics.pre3.SetActive(true);
				Statics.pre4.SetActive(true);
				Statics.DescP.SetActive(true);
				Statics.DescP.GetComponent<TextMesh>().text = "Nivel Actual= \n" + "Velocidad Aumentada \n Coste: ";
				State=1;
			}			
			else if (Statics.GameOver.activeSelf)
			{
				Statics.RestartGame=true;
			}
			else if(Statics.Paused == true)
			{
				Statics.Paused = false;			
				Statics.GameOver.SetActive(false);
				Statics.Menu.SetActive(false);
				Statics.HUD.SetActive(true);
			}
		}
		else if (Input.GetKeyDown(KeyCode.Escape) && !Statics.Paused) 	   	
		{
			Statics.Paused = true;
			Statics.Menu.SetActive(true);
			GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
		}	
		else if (Input.GetKeyDown(KeyCode.Escape) && Statics.Paused)
		{
			Debug.Log("QUIT");
			Application.Quit();
		}
		if (Input.GetMouseButtonUp(0) && State==1)
		{
			if (Input.mousePosition.x >= 743 && Input.mousePosition.x <= 763
				&& Input.mousePosition.y >= 54 && Input.mousePosition.y <= 74)
			{
				Statics.Player.GetComponent<Avanzar>().Speed = true;
			}
			Statics.pre1.SetActive(false);
			Statics.pre2.SetActive(false);
			Statics.pre3.SetActive(false);
			Statics.pre4.SetActive(false);
			Statics.DescP.SetActive(false);
			
			Debug.Log(Input.mousePosition);
			Debug.Log(Input.mousePosition+new Vector3(10,10,0));
			Debug.Log(Input.mousePosition-new Vector3(10,10,0));
			State=0;
		}
	}	
}
