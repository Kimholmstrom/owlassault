using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject Enemy;
	public int spawnRangeX;
	public int spawnRangeY;
	public int spawnPointZ;
	private Vector3 direction;
	public int EnemyCount;
	public float spawnPause;
	public float startPause;

	bool paused = false;	

	void Start ()
	{
		StartCoroutine (Spawn ());
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			paused = togglePause();
		}
	}
	
	IEnumerator Spawn ()
	{
		yield return new WaitForSeconds (startPause);
		while (true)
		{
			for (int i = 0; i < EnemyCount; i++)
			{
				int spawnX = Random.Range (-spawnRangeX, spawnRangeX);
				int spawnY = Random.Range (-spawnRangeY, spawnRangeY);
				direction = new Vector3 (spawnX, spawnY, spawnPointZ);
				Instantiate (Enemy, direction, transform.rotation);
				yield return new WaitForSeconds (spawnPause);
			}
			break;
		}
	}

	void OnGUI()
	{
		if(paused)
		{
			// Make a background box
			GUI.Box(new Rect((Screen.width/2)-70,(Screen.height/2)-45,140,100), "Own Assault");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect((Screen.width/2)-50,(Screen.height/2)-10,100,20), "Resume Game")) {
				paused = togglePause();
			}
			
			if(GUI.Button(new Rect((Screen.width/2)-50,(Screen.height/2)+20,100,20), "Exit")) {
				Application.Quit();
			}

		}
	}
	
	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);   
		}
	}
}
