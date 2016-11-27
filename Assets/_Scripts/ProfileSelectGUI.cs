using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class ProfileSelectGUI : MonoBehaviour
{
    public Texture backgroundImage;
    //public Texture profile1Button;
    

    void OnGUI()
    {
        //Debug.Log(Application.persistentDataPath);

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);

        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 20, 100, 30), "Profile 1"))
        {
            GameControl.playerProfile = 1;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 30), "Profile 2"))
        {
            GameControl.playerProfile = 2;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 100, 100, 30), "Profile 3"))
        {
            GameControl.playerProfile = 3;

            SceneManager.LoadScene("MainMenu"); // Loads the scene by name
        }
    }
}
