﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary; // Needed for saving in binary to a file.
using System.IO; // For Input Output file stream stuff.
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class GameControl : MonoBehaviour
{
    // public static reference variable to this class.
    //public static GameControl control;

    public static string currentScene;
    public static int playerProfile; // Will be a number 1, 2, or 3 that corresponds to the profile chosen at the start of a new game.
    public static bool hasData1;
    public static bool hasData2;
    public static bool hasData3;
    public static bool beatGame1;
    public static bool beatGame2;
    public static bool beatGame3;

    // Awake is called before Start
    void Awake()
    {
        //currentScene = SceneManager.GetActiveScene().name;

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
    public static void Save(string fileName)
    {
        //hasData = true;
        currentScene = SceneManager.GetActiveScene().name;

        BinaryFormatter bf = new BinaryFormatter();

        // Unity uses the persistent data path (hidden files)
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        PlayerData data = new PlayerData(); // Instance of class PlayerData (below)

        // Setting PlayerData info to local info.
        data.currentScene = currentScene;
        data.playerProfile = playerProfile;
        data.hasData1 = hasData1;
        data.hasData2 = hasData2;
        data.hasData3 = hasData3;
        data.beatGame1 = beatGame1;
        data.beatGame2 = beatGame2;
        data.beatGame3 = beatGame3;

        bf.Serialize(file, data); // Writes data to a file.
        file.Close();
    }

    /// <summary>
    /// Loads data from a file.
    /// fileName is passed in in the MainMenuGUI Script.
    /// </summary>
    public static void Load(string fileName)
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
            hasData1 = data.hasData1;
            hasData2 = data.hasData2;
            hasData3 = data.hasData3;
            beatGame1 = data.beatGame1;
            beatGame2 = data.beatGame2;
            beatGame3 = data.beatGame3;
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
    public string currentScene;
    public int playerProfile;
    public bool hasData1;
    public bool hasData2;
    public bool hasData3;
    public bool beatGame1;
    public bool beatGame2;
    public bool beatGame3;
}
