using UnityEngine;
using System.Collections;

public class MenuBehaviour : MonoBehaviour {
		
	public int State = 0;
	// Use this for initialization
	void Start () 
	{		
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
				Statics.PreC.SetActive(false);
				Statics.PreC.GetComponent<PreAdqBehaviour>().Swich(false);
			}
		}
		//MOUSE
		else if (Input.GetMouseButtonDown(0) && Statics.Paused)
		{	
			
			if (Statics.GameOver.activeSelf)
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
			Statics.PreC.SetActive(true);
			Statics.Menu.SetActive(true);
			GameObject.FindGameObjectWithTag(Constants.TAG_MAIN).GetComponent<GameProgression>().Save();
		}	
		else if (Input.GetKeyDown(KeyCode.Escape) && Statics.Paused)
		{
			Debug.Log("QUIT");
			//Application.Quit();
		}
		if (Input.GetMouseButtonUp(0) && State==1)
		{
			if (Input.mousePosition.x >= 743 && Input.mousePosition.x <= 763
				&& Input.mousePosition.y >= 54 && Input.mousePosition.y <= 74)
			{
				Statics.Player.GetComponent<Avanzar>().Speed = true;
			}
			State=0;
		}
	}	
}
