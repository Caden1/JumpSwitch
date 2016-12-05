using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class LevelSelectGUI : MonoBehaviour
{
    public Texture backgroundImage;

	public AudioClip buttonClick;
	AudioSource audio;

    void Start()
    {
		audio = GetComponent<AudioSource>();

        // Put in the start function so it's only called once.
        if (GameControl.playerProfile == 1)
        {
            GameControl.Load("/player1Info.dat"); // Will fill GameControl variables from file.
        }
        else if (GameControl.playerProfile == 2)
        {
            GameControl.Load("/player2Info.dat");
        }
        else if (GameControl.playerProfile == 3)
        {
            GameControl.Load("/player3Info.dat");
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);

		if (GameControl.currentScene == "6Tower2") // Sanity check to make sure the player has really beaten the game.
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 40, 100, 30), "Level 1"))
			{
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level1Load", 0.3f); // Delays load for 0.3 seconds.
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 30), "Level 2"))
			{
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level2Load", 0.3f); // Delays load for 0.3 seconds.
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 20, 100, 30), "Level 3"))
			{
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level3Load", 0.3f); // Delays load for 0.3 seconds.
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 100, 30), "Level 4"))
			{
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level4Load", 0.3f); // Delays load for 0.3 seconds.
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 80, 100, 30), "Level 5"))
			{
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level5Load", 0.3f); // Delays load for 0.3 seconds.
			}
		}

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 140, 100, 30), "Back"))
        {
			audio.PlayOneShot(buttonClick, 2f);

			Invoke ("MainMenuLoad", 0.3f); // Delays load for 0.3 seconds.
        }
    }

	private void Level1Load()
	{
		SceneManager.LoadScene("1Prison1"); // Loads the scene by name
	}

	private void Level2Load()
	{
		SceneManager.LoadScene("2Prison2"); // Loads the scene by name
	}

	private void Level3Load()
	{
		SceneManager.LoadScene("3Cave1"); // Loads the scene by name
	}

	private void Level4Load()
	{
		SceneManager.LoadScene("4Cave2"); // Loads the scene by name
	}

	private void Level5Load()
	{
		SceneManager.LoadScene("6Tower2"); // Loads the scene by name
	}

	private void MainMenuLoad()
	{
		SceneManager.LoadScene("MainMenu"); // Loads the scene by name
	}
}
