using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class WinZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // When the object is collided with
        {
            // Level Progression:

			if (SceneManager.GetActiveScene().name == "1Prison1") // If current scene is the Prison1 scene
            {
				SceneManager.LoadScene("2Prison2"); // Loads Playground
            }

			if (SceneManager.GetActiveScene().name == "2Prison2") // If current scene is the Playground scene
            {
				SceneManager.LoadScene("3Cave1"); // Loads Level4
            }

			if (SceneManager.GetActiveScene().name == "3Cave1") // If current scene is the Level4 scene
            {
				SceneManager.LoadScene("4Cave2"); // Loads Prison1
            }

			if (SceneManager.GetActiveScene().name == "4Cave2") // If current scene is the Level4 scene
			{
				SceneManager.LoadScene("6Tower2"); // Loads Prison1
            }

			if (SceneManager.GetActiveScene().name == "6Tower2") // If current scene is the Level4 scene
			{
				SceneManager.LoadScene("1Prison1"); // Loads Prison1
			}
        }
    }
}
