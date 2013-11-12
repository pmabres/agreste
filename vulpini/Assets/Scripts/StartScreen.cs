using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

  	public Texture2D texture;
    static StartScreen instance;
 	private int aValue;
	private float time=0.2f;
	AsyncOperation async;
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;    
        gameObject.AddComponent<GUITexture>().enabled = true;
        guiTexture.texture = texture;
		transform.localScale = new Vector3(0.18f,0.3f,0);
        transform.position = new Vector3(0.5f, 0.5f, 0.0f);
        DontDestroyOnLoad(this);
		Color c = guiTexture.color;
		c.a = 0;
		aValue=2;
		guiTexture.color = c;
    }
 	public void Update()
	{
		Color c = guiTexture.color;
		c.a = Mathf.Lerp (c.a,aValue,Time.deltaTime*time);
		guiTexture.color = c;
		if (c.a > 0.9f)
		{
			Debug.Log("Algo");			
			StartLoading();
			ActivateScene();
			aValue = -1;
			time = 0.5f;
		}		
	}
	
	public void StartLoading() {
	    StartCoroutine("load");
	}
	 
	IEnumerator load() {
	    Debug.LogWarning("ASYNC LOAD STARTED - " +
	       "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
	    async = Application.LoadLevelAsync("level1");
	    async.allowSceneActivation = false;
	    yield return async;
	}
	 
	public void ActivateScene() {
	    async.allowSceneActivation = true;
	}	 
	
    public static void Load(int index)
    {
        if (NoInstance()) return;        
        Application.LoadLevel(index);        
    }
 
    public static void Load(string name)
    {
        if (NoInstance()) return;        
        Application.LoadLevel(name);        
    }
 
    static bool NoInstance()
    {
        if (!instance)
            Debug.LogError("Loading Screen is not existing in scene.");
        return instance;
    }
}
