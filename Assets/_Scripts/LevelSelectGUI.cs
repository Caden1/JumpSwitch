using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class LevelSelectGUI : MonoBehaviour
{
    void Start()
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
        if (GameControl.currentScene == "1Prison1")
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "Level 1"))
            {
                SceneManager.LoadScene("1Prison1"); // Loads the scene by name
            }
        }
        else if (GameControl.currentScene == "2Prison2")
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "Level 1"))
            {
                SceneManager.LoadScene("1Prison1"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 140, 100, 30), "Level 2"))
            {
                SceneManager.LoadScene("2Prison2"); // Loads the scene by name
            }
        }
        else if (GameControl.currentScene == "3Cave1")
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "Level 1"))
            {
                SceneManager.LoadScene("1Prison1"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 140, 100, 30), "Level 2"))
            {
                SceneManager.LoadScene("2Prison2"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 180, 100, 30), "Level 3"))
            {
                SceneManager.LoadScene("3Cave1"); // Loads the scene by name
            }
        }
        else if (GameControl.currentScene == "4Cave2")
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "Level 1"))
            {
                SceneManager.LoadScene("1Prison1"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 140, 100, 30), "Level 2"))
            {
                SceneManager.LoadScene("2Prison2"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 180, 100, 30), "Level 3"))
            {
                SceneManager.LoadScene("3Cave1"); // Loads the scene by name
            }
            if (GUI.Button(new Rect(10, 220, 100, 30), "Level 4"))
            {
                SceneManager.LoadScene("4Cave2"); // Loads the scene by name
            }
        }

		else if (GameControl.currentScene == "6Tower2")
		{
			if (GUI.Button(new Rect(10, 100, 100, 30), "Level 1"))
			{
				SceneManager.LoadScene("1Prison1"); // Loads the scene by name
			}
			if (GUI.Button(new Rect(10, 140, 100, 30), "Level 2"))
			{
				SceneManager.LoadScene("2Prison2"); // Loads the scene by name
			}
			if (GUI.Button(new Rect(10, 180, 100, 30), "Level 3"))
			{
				SceneManager.LoadScene("3Cave1"); // Loads the scene by name
			}
			if (GUI.Button(new Rect(10, 220, 100, 30), "Level 4"))
			{
				SceneManager.LoadScene("4Cave2"); // Loads the scene by name
			}
			if (GUI.Button(new Rect(10, 260, 100, 30), "Level 5"))
			{
				SceneManager.LoadScene("6Tower2"); // Loads the scene by name
			}
		}

        if (GUI.Button(new Rect(10, 340, 100, 30), "Back"))
        {
            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
    }
}
