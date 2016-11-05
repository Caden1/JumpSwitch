using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class WinZone : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // When the object is collided with
        {
            // Level Progression:

            if (SceneManager.GetActiveScene().name == "Prison1") // If current scene is the Prison1 scene
            {
                SceneManager.LoadScene("Playground"); // Loads Playground
            }

            if (SceneManager.GetActiveScene().name == "Playground") // If current scene is the Playground scene
            {
                SceneManager.LoadScene("Level02"); // Loads level 2
            }

            if (SceneManager.GetActiveScene().name == "Level02") // If current scene is the Level02 scene
            {
                SceneManager.LoadScene("Prison1"); // Loads Prison1
            }
        }
    }
}
