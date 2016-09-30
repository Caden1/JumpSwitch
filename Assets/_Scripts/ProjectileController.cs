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
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y); // Makes the projectile move at speed specified
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject); // Destroys the projectile
    }
}
