using UnityEngine;
using System.Collections;

public class OwlController : MonoBehaviour {

	//variables
	public float MoveSpeed;
	public int Health;
	public float fallSpeed;
	public int slowDownWhenDead;
	public float deathTime;

	private GameObject Player;
	private PlayerController playercontroller;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player");
		playercontroller = Player.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 direction = Vector3.zero;
		direction.z = -1;
		float speed = MoveSpeed;

		rigidbody.velocity = direction*speed;
	}

	/*
	 * //when clicked
	void OnMouseDown () {
		this.Health = this.Health - playercontroller.Damage;
		if (this.Health < 1) 
		{
			StartCoroutine (Die ());
		}
	}
	*/

	IEnumerator Die()
	{
		rigidbody.drag = slowDownWhenDead; 
		Destroy(collider);
		yield return new WaitForSeconds (deathTime);
		Destroy(gameObject);
		playercontroller.Score += 1;
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{

			playercontroller.Health = playercontroller.Health -1;
			Destroy (gameObject);
		}
	}
	

}
