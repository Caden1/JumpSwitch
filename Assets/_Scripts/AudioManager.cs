using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public AudioClip newAudio; // Assign in the inspector

	void Awake ()
    {
        GameObject audioToPlay = GameObject.Find("AudioObject"); // Will find the game object with the audio source applied.

        if (audioToPlay.GetComponent<AudioSource>().clip != newAudio) // Prevents the new audio from replaying with every scene.
        {
            audioToPlay.GetComponent<AudioSource>().clip = newAudio; // Replaces the old audio with the new audio

            audioToPlay.GetComponent<AudioSource>().Play(); // Plays the new audio
        }

    }
}
