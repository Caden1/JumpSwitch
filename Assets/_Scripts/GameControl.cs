using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary; // Needed for saving in binary to a file.
using System.IO; // For Input Output file stream stuff.
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class GameControl : MonoBehaviour
{
    // public static reference variable to this class.
    //public static GameControl control;

    public static String currentScene;
    public static int playerProfile; // Will be a number 1, 2, or 3 that corresponds to the profile chosen at the start of a new game.
    public static bool hasData;
    public static int furthestLevel;

    // Awake is called before Start
    void Awake()
    {
        currentScene = SceneManager.GetActiveScene().name;

        // Becasuse I'm only saving the current scene and player profile, I don't need a singleton:
        /*
        ////////// Start Singleton:
        // If there is no current game control, make this the one game control.
        if (control == null)
        {
            DontDestroyOnLoad(gameObject); // Whatever game object this script is on will persist from scene to scene.
            control = this;
        }
        else if(control != this) // if control does exist and this is not it.
        {
            Destroy(gameObject); // Destroy the gameObject in this scene. It'll be replaced by the one that already exists.
        }
        ////////// End Singleton
        */
    }

    /// <summary>
    /// Saves data to a file.
    /// fileName is passed in in the SaveGameCollider Script.
    /// </summary>
    public static void Save(String fileName)
    {
        hasData = true;

        BinaryFormatter bf = new BinaryFormatter();

        // Unity uses the persistent data path (hidden files): User->App Data->Roaming......
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        PlayerData data = new PlayerData(); // Instance of class PlayerData (below)

        // Setting PlayerData info to local info.
        data.currentScene = currentScene;
        data.playerProfile = playerProfile;
        data.hasData = hasData;

        bf.Serialize(file, data); // Writes data to a file.
        file.Close();
    }

    /// <summary>
    /// Loads data from a file.
    /// fileName is passed in in the MainMenuGUI Script.
    /// </summary>
    public static void Load(String fileName)
    {
        if (File.Exists(Application.persistentDataPath + fileName)) // If the file exists. "/player1Info.dat" is the file for profile 1.
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open); // "/player1Info.dat" is the file for profile 1.
            PlayerData data = (PlayerData)bf.Deserialize(file); // Pulls from the file. Needs to cast to a PlayerData object because the type of object is unknown.
            file.Close();

            // Setting local info to PlayerData info.
            currentScene = data.currentScene;
            playerProfile = data.playerProfile;
            hasData = data.hasData;
        }
    }

    /* Used to test
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Profile " + playerProfile);
    }
    */
}

/// <summary>
/// This class contains the data that will be saved to a file. the Serializable keyword tells Unity that I can save it to a file.
/// </summary>
[Serializable]
class PlayerData
{
    public String currentScene;
    public int playerProfile;
    public bool hasData;
}
