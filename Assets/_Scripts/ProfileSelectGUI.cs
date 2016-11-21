using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class ProfileSelectGUI : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 100, 100, 30), "Profile 1"))
        {
            GameControl.playerProfile = 1;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
        if (GUI.Button(new Rect(10, 140, 100, 30), "Profile 2"))
        {
            GameControl.playerProfile = 2;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Profile 3"))
        {
            GameControl.playerProfile = 3;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
    }
}
