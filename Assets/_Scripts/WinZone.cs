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
                // if ((GameControl.playerProfile == 1 && GameControl.beatGame1 == true) || (GameControl.playerProfile == 2 && GameControl.beatGame2 == true)
                //      || (GameControl.playerProfile == 3 && GameControl.beatGame3 == true)) // Player has beaten the game.

                // The player has beaten the game at this point. Now unlock level select.
                if (GameControl.playerProfile == 1)
                {
                    GameControl.beatGame1 = true;
                }
                else if (GameControl.playerProfile == 2)
                {
                    GameControl.beatGame2 = true;
                }
                else if (GameControl.playerProfile == 3)
                {
                    GameControl.beatGame3 = true;
                }

                // Save to specific file depending on the player profile chosen. Need to save again so the beatGame variable is saved.
                if (GameControl.playerProfile == 1)
                {
                    GameControl.Save("/player1Info.dat");
                }
                else if (GameControl.playerProfile == 2)
                {
                    GameControl.Save("/player2Info.dat");
                }
                else if (GameControl.playerProfile == 3)
                {
                    GameControl.Save("/player3Info.dat");
                }

                SceneManager.LoadScene("MainMenu"); // Loads MainMenu
            }
        }
    }
}
