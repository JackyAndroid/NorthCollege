using UnityEngine;
using System.Collections;

public class MainCam : MonoBehaviour {
public Texture2D buttonPic;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		int width = Screen.width - 200;
		int height = Screen.height - 200;
	
		if(GUI.Button(new Rect(width,height,150,150),buttonPic)){
			Application.Quit();
		}
		if (GUI.Button(new Rect (width-300, height, 300, 100), "10计科王世昌 点击打开博客")) {
			Application.OpenURL("http://blog.csdn.net/rain_butterfly");
		}

		if(Application.platform == RuntimePlatform.Android &&(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home) )){
			Application.Quit();
		}
	}
}
