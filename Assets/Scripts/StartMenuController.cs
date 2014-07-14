using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour {



	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect((Screen.width/2)-50,(Screen.height/2)-45,100,100), "Own Assault");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect((Screen.width/2)-40,(Screen.height/2)-10,80,20), "Start Game")) {
			Application.LoadLevel("Level_01");
		}

		if(GUI.Button(new Rect((Screen.width/2)-40,(Screen.height/2)+20,80,20), "Exit")) {
			Application.Quit();
		}
	
	}

}
