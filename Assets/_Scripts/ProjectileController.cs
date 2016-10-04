using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10;
    public PlayerController player;

	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0) // If the player is facing left
        {
            speed = -speed; // Shoot the projectile to the left
        }

		//Destroy (gameObject, 2); // Destroy projectile after 2 seconds
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); // Makes the projectile move at speed specified
	}
		
	void OnTriggerEnter2D(Collider2D other) // Collision not being detected
    {
		Debug.Log ("Hit");
		if (other.tag == "Wall") 
		{
			//Debug.Log ("Hit");
			Destroy(gameObject); // Destroys the projectile
		}
    }
	/*
	void OnCollisionEnter2D(Collision2D coll) // Collision not being detected
	{
		Debug.Log ("Hit");
		if (coll.gameObject.name == "Wall") 
		{
			//Debug.Log ("Hit");
			Destroy(gameObject); // Destroys the projectile
		}
	}
	*/
}
