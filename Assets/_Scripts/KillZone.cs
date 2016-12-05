using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class KillZone : MonoBehaviour
{
    public PlayerController player;

    // For death sound
    public float deathVolume = 0.5f;
    public AudioClip deathSound;
    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();

        audio = GetComponent<AudioSource>();
    }
		
    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
            audio.PlayOneShot(deathSound, deathVolume);

            PlayerController.respawnNotDeath = false; // Set to false if the player dies.

            LoadScenesAndCheckpoints ();
		}
	}

	public void LoadScenesAndCheckpoints() // Also called in the PlayerController Script
	{
		if (SceneManager.GetActiveScene().name == "1Prison1") // If current scene is the Prison1 scene
		{
			Prison1Scene();
		}

		if (SceneManager.GetActiveScene().name == "2Prison2") // If current scene is the Prison1 scene
		{
			Prison2Scene();
		}

		if (SceneManager.GetActiveScene().name == "3Cave1") // If current scene is the Playground scene
		{
			Cave1Scene();
		}

		if (SceneManager.GetActiveScene().name == "4Cave2") // If current scene is the Level4 scene
		{
			Cave2Scene();
		}

		if (SceneManager.GetActiveScene().name == "6Tower2") // If current scene is the Level4 scene
		{
			Tower2Scene();
		}
	}

    private void Prison1Scene()
    {
        if (CheckPoint.checkPoint1Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint1").transform.position;
        }
        else if (CheckPoint.checkPoint2Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint2").transform.position;
        }
        else
        {
            SceneManager.LoadScene("1Prison1"); // Loads the scene by name
        }
    }

	private void Prison2Scene()
	{
		if (CheckPoint.checkPoint1Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint1").transform.position;
		} 
		else if (CheckPoint.checkPoint2Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint2").transform.position;
		} 
		else if (CheckPoint.checkPoint3Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint3").transform.position;
		} 
		else 
		{
			player.transform.position = GameObject.Find ("CheckPoint1").transform.position;
		}
	}

    private void Cave1Scene()
    {
        if (CheckPoint.checkPoint1Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint1").transform.position;
        }
        else if (CheckPoint.checkPoint2Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint2").transform.position;
        }
		else if (CheckPoint.checkPoint3Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint3").transform.position;
		} 
        else
        {
			SceneManager.LoadScene("3Cave1"); // Loads the scene by name
        }

        //Debug.Log("checkPoint1Active: " + CheckPoint.checkPoint1Active);
        //Debug.Log("checkPoint2Active: " + CheckPoint.checkPoint2Active);
    }

	private void Cave2Scene()
    {
        if (CheckPoint.checkPoint1Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint1").transform.position;
        }
        else if (CheckPoint.checkPoint2Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint2").transform.position;
        }
        else
        {
			SceneManager.LoadScene("4Cave2"); // Loads the scene by name
        }
    }

	private void Tower2Scene()
	{
		if (CheckPoint.checkPoint1Active == true)
		{
			player.transform.position = GameObject.Find("CheckPoint1").transform.position;
		}
		else if (CheckPoint.checkPoint2Active == true)
		{
			player.transform.position = GameObject.Find("CheckPoint2").transform.position;
		}
		else if (CheckPoint.checkPoint3Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint3").transform.position;
		} 
		else if (CheckPoint.checkPoint4Active == true)
		{
			player.transform.position = GameObject.Find("CheckPoint4").transform.position;
		}
		else if (CheckPoint.checkPoint5Active == true)
		{
			player.transform.position = GameObject.Find("CheckPoint5").transform.position;
		}
		else if (CheckPoint.checkPoint6Active == true) 
		{
			player.transform.position = GameObject.Find ("CheckPoint6").transform.position;
		}
        else if (CheckPoint.checkPoint7Active == true)
        {
            player.transform.position = GameObject.Find("CheckPoint7").transform.position;
        }
        else
		{
			SceneManager.LoadScene("6Tower2"); // Loads the scene by name
		}
	}
}
