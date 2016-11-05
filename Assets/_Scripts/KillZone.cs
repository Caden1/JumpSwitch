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
            if (SceneManager.GetActiveScene().name == "Prison1") // If current scene is the Prison1 scene
            {
                Prison1dScene();
            }

            if (SceneManager.GetActiveScene().name == "Playground") // If current scene is the Playground scene
            {
                PlaygroundScene();
            }

            if (SceneManager.GetActiveScene().name == "Level02") // If current scene is the Level02 scene
            {
                Level02Scene();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name == "Prison1") // If current scene is the Prison1 scene
            {
                Prison1dScene();
            }

            if (SceneManager.GetActiveScene().name == "Playground") // If current scene is the Playground scene
            {
                PlaygroundScene();
            }

            if (SceneManager.GetActiveScene().name == "Level02") // If current scene is the Level02 scene
            {
                Level02Scene();
            }
        }
    }

    private void Prison1dScene()
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
            SceneManager.LoadScene("Prison1"); // Loads the scene by name
        }
    }

    private void PlaygroundScene()
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
            SceneManager.LoadScene("Playground"); // Loads the scene by name
        }

        //Debug.Log("checkPoint1Active: " + CheckPoint.checkPoint1Active);
        //Debug.Log("checkPoint2Active: " + CheckPoint.checkPoint2Active);
    }

    private void Level02Scene()
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
            player.transform.position = GameObject.Find("CheckPoint3").transform.position;
        }
        else
        {
            SceneManager.LoadScene("Level02"); // Loads the scene by name
        }
    }
}
