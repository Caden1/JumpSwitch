using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class CheckPoint : MonoBehaviour
{
    // For Check Points
    // Static so they can be used in KillZone Script
    [HideInInspector]
    public static bool checkPoint1Active; 
    [HideInInspector]
    public static bool checkPoint2Active;
    [HideInInspector]
    public static bool checkPoint3Active;

    [HideInInspector]
    public static int furthestAlong;

    // Use this for initialization
    void Start ()
    {
        checkPoint1Active = false;
        checkPoint2Active = false;
        checkPoint3Active = false;
        furthestAlong = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
			if (SceneManager.GetActiveScene().name == "1Prison1") // If current scene is the Playground scene
            {
                if (gameObject.name == "CheckPoint1" && furthestAlong == 1)
                {
                    checkPoint1Active = true;
                    checkPoint2Active = false;
                    furthestAlong = 2;
                }
                else if (gameObject.name == "CheckPoint2" && furthestAlong == 2)
                {
                    checkPoint1Active = false;
                    checkPoint2Active = true;
                }
            }
                
			if (SceneManager.GetActiveScene().name == "2Prison2") // If current scene is the Playground scene
            {
                if (gameObject.name == "CheckPoint1" && furthestAlong == 1)
                {
                    checkPoint1Active = true;
                    checkPoint2Active = false;
					checkPoint3Active = false;
                    furthestAlong = 2;
                }
                else if (gameObject.name == "CheckPoint2" && furthestAlong == 2)
                {
                    checkPoint1Active = false;
                    checkPoint2Active = true;
					checkPoint3Active = false;
					furthestAlong = 3;
                }
				else if (gameObject.name == "CheckPoint3" && furthestAlong == 3)
				{
					checkPoint1Active = false;
					checkPoint2Active = false;
					checkPoint3Active = true;
				}
            }

			if (SceneManager.GetActiveScene().name == "3Cave1") // If current scene is the Level4 scene
            {
                if (gameObject.name == "CheckPoint1" && furthestAlong == 1)
                {
                    checkPoint1Active = true;
                    checkPoint2Active = false;
                    furthestAlong = 2;
                }
                else if (gameObject.name == "CheckPoint2" && furthestAlong == 2)
                {
                    checkPoint1Active = false;
                    checkPoint2Active = true;
                }
            }

			if (SceneManager.GetActiveScene().name == "4Cave2") // If current scene is the Level4 scene
			{
				if (gameObject.name == "CheckPoint1" && furthestAlong == 1)
				{
					checkPoint1Active = true;
					checkPoint2Active = false;
					furthestAlong = 2;
				}
				else if (gameObject.name == "CheckPoint2" && furthestAlong == 2)
				{
					checkPoint1Active = false;
					checkPoint2Active = true;
				}
			}
        }
    }
}
