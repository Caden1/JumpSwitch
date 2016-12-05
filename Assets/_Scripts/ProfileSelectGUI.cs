using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class ProfileSelectGUI : MonoBehaviour
{
    public Texture backgroundImage;
    //public Texture profile1Button;

	public AudioClip buttonClick;
	AudioSource audio;

	void Start()
	{
		audio = GetComponent<AudioSource>();
	}
    

    void OnGUI()
    {
        //Debug.Log(Application.persistentDataPath);

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);

        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 100, 100, 30), "Profile 1"))
        {
			audio.PlayOneShot(buttonClick, 2f);

            GameControl.playerProfile = 1;

			Invoke ("MainMenuLoad", 0.3f); // Delays load for 0.3 seconds.
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 30, 100, 30), "Profile 2"))
        {
			audio.PlayOneShot(buttonClick, 2f);

            GameControl.playerProfile = 2;

			Invoke ("MainMenuLoad", 0.3f); // Delays load for 0.3 seconds.
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Profile 3"))
        {
			audio.PlayOneShot(buttonClick, 2f);

            GameControl.playerProfile = 3;

			Invoke ("MainMenuLoad", 0.3f); // Delays load for 0.3 seconds.
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 110, 100, 30), "Quit"))
        {
            audio.PlayOneShot(buttonClick, 2f);

            Invoke("QuitGame", 0.3f); // Delays load for 0.3 seconds.
        }
    }

	private void MainMenuLoad()
	{
		SceneManager.LoadScene("MainMenu"); // Loads the scene by name
	}

    private void QuitGame()
    {
        Application.Quit(); // Quits the application
    }
}
