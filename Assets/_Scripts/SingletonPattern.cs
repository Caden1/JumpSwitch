using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class SingletonPattern : MonoBehaviour
{
    private static SingletonPattern instance;

	void Awake ()
    {
        ////////// Start Singleton:
        if (SceneManager.GetActiveScene().name == "1Prison1")
        {
            Destroy(gameObject);
        }
        // If there is no current instance, make this the one the instance.
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject); // Whatever game object this script is on will persist from scene to scene.
            instance = this;
        }
        else if (instance != this) // if instance does exist and this is not it.
        {
            Destroy(gameObject); // Destroy the gameObject in this scene. It'll be replaced by the one that already exists.
        }
        ////////// End Singleton
    }
}
