using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int Health;
	public int Damage; 
	public int Score;

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit = new RaycastHit();
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag == "Enemy") {
					Destroy(hit.collider.gameObject);
				}
			}
		}
	}

	void ShootProjectile()
	{
		Ray ray = camera.ScreenPointToRay(new Vector3(200, 200, 0));
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
	}

}
