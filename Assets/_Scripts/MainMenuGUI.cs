using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class MainMenuGUI : MonoBehaviour
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
        //Debug.Log(Application.persistentDataPath.ToString());

        if (GameControl.hasData == false) // Profile has no saved data.
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "New Game"))
            {
                SceneManager.LoadScene("1Prison1"); // Loads the scene by name
            }
        }
        else // There is saved data.
        {
            if (GUI.Button(new Rect(10, 100, 100, 30), "Continue"))
            {
                SceneManager.LoadScene(GameControl.currentScene); // Loads the scene by name
            }
        }
        
        if (GUI.Button(new Rect(10, 140, 100, 30), "Level Select"))
        {
            SceneManager.LoadScene("LevelSelect"); // Loads the scene by name
        }
        /*
        if (GUI.Button(new Rect(10, 220, 100, 30), "Change Key Bindings"))
        {
            //GameControl.Load(); // Will fill GameControl variables from file depending on profile selected.

            //SceneManager.LoadScene(); // Loads the scene by name
        }
        */
        if (GUI.Button(new Rect(10, 340, 100, 30), "Back"))
        {
            SceneManager.LoadScene("ProfileSelect"); // Loads the scene by name
        }
    }
}
