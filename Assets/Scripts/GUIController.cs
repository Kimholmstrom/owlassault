using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	//The containers for the GUI objects
	public GameObject LifeCounter;
	public GameObject ScoreCounter;
	
	//Position of the counters, to be set in the editor (0.0 is lower left, 1.1 is top right)
	public Vector3 LifeCounterLocation;
	public Vector3 ScoreCounterLocation;

	public int fontSize;

	//For connecting to get plater data
	private GameObject Player;
	private PlayerController playercontroller;


	// Use this for initialization
	void Start () {

		LifeCounter = new GameObject();
		ScoreCounter = new GameObject();

		//Initialize the life counter GUI	
		LifeCounter.transform.position = LifeCounterLocation;
		LifeCounter.AddComponent<GUIText>();
		
		//Initialize the score counter GUI
		ScoreCounter.transform.position = ScoreCounterLocation;
		ScoreCounter.AddComponent<GUIText>();

		//Connect to playerController to get Health and score value
		Player = GameObject.Find("Player");
		playercontroller = Player.GetComponent<PlayerController>();

		//Set font size
		LifeCounter.guiText.fontSize = fontSize;
		ScoreCounter.guiText.fontSize = fontSize;

		//Set starting values
		LifeCounter.guiText.text = "Life: " + playercontroller.Health;
		ScoreCounter.guiText.text = "Score: " + playercontroller.Score;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		LifeCounter.guiText.text = "Life: " + playercontroller.Health;
		ScoreCounter.guiText.text = "Score: " + playercontroller.Score;
	}


}

