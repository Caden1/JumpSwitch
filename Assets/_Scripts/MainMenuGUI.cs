using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class MainMenuGUI : MonoBehaviour
{
    public Texture backgroundImage;

	public AudioClip buttonClick;
	AudioSource audio;

	void Start()
	{
		audio = GetComponent<AudioSource>();
	}

    void Awake()
    {
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
        //Debug.Log(Application.persistentDataPath.ToString());

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);


        if ((GameControl.playerProfile == 1 && GameControl.hasData1 == true) || (GameControl.playerProfile == 2 && GameControl.hasData2 == true)
            || (GameControl.playerProfile == 3 && GameControl.hasData3 == true)) // There is saved data.
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 30), "Continue"))
            {
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("ContinueGameLoad", 0.3f); // Delays load for 0.3 seconds.
            }
        }
        else // Profile has no saved data.
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 30), "New Game"))
            {
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("Level1Load", 0.3f); // Delays load for 0.3 seconds.
            }
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 30), "Controls"))
        {
            audio.PlayOneShot(buttonClick, 2f);

            Invoke("ControlsLoad", 0.3f); // Delays load for 0.3 seconds.
        }

        if ((GameControl.playerProfile == 1 && GameControl.beatGame1 == true) || (GameControl.playerProfile == 2 && GameControl.beatGame2 == true)
            || (GameControl.playerProfile == 3 && GameControl.beatGame3 == true)) // Player has beaten the game.
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Level Select"))
            {
				audio.PlayOneShot(buttonClick, 2f);

				Invoke ("LevelSelectLoad", 0.3f); // Delays load for 0.3 seconds.
            }
        }
        /*
        if (GUI.Button(new Rect(10, 220, 100, 30), "Change Key Bindings"))
        {
            //GameControl.Load(); // Will fill GameControl variables from file depending on profile selected.

            //SceneManager.LoadScene(); // Loads the scene by name
        }
        */
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 110, 100, 30), "Back"))
        {
			audio.PlayOneShot(buttonClick, 2f);

			Invoke ("ProfileSelectLoad", 0.3f); // Delays load for 0.3 seconds.
        }
    }

	private void ContinueGameLoad()
	{
		SceneManager.LoadScene(GameControl.currentScene); // Loads the scene by name
	}

	private void Level1Load()
	{
		SceneManager.LoadScene("1Prison1"); // Loads the scene by name
	}

    private void ControlsLoad()
    {
        SceneManager.LoadScene("Controls"); // Loads the scene by name
    }

    private void LevelSelectLoad()
	{
		SceneManager.LoadScene("LevelSelect"); // Loads the scene by name
	}

	private void ProfileSelectLoad()
	{
		SceneManager.LoadScene("ProfileSelect"); // Loads the scene by name
	}
}
