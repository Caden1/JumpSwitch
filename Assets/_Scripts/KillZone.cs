using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class KillZone : MonoBehaviour
{
    public PlayerController player;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // For going to last check point
        if (Input.GetKeyDown(KeyCode.R))
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
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
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
}
