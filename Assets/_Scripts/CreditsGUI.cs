using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class CreditsGUI : MonoBehaviour
{
    public Texture backgroundImage;

    public AudioClip buttonClick;
    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);

        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 300, 100, 30), "Back"))
        {
            audio.PlayOneShot(buttonClick, 2f);

            Invoke("ProfileSelectLoad", 0.3f); // Delays load for 0.3 seconds.
        }
    }

    private void ProfileSelectLoad()
    {
        SceneManager.LoadScene("ProfileSelect"); // Loads the scene by name
    }
}
