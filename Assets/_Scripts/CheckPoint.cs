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
	public static bool checkPoint4Active;
	[HideInInspector]
	public static bool checkPoint5Active;
	[HideInInspector]
	public static bool checkPoint6Active;

    [HideInInspector]
    public static int furthestAlong;


	Animator animator;

    // Use this for initialization
    void Start ()
    {
        checkPoint1Active = false;
        checkPoint2Active = false;
        checkPoint3Active = false;
		checkPoint4Active = false;
		checkPoint5Active = false;
		checkPoint6Active = false;
        furthestAlong = 1;

		animator = GetComponent<Animator> ();

    }

    void OnTriggerEnter2D(Collider2D col)
    {	
		
        if (col.tag == "Player")
        {	
			
			animator.SetTrigger ("activate");

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

			if (SceneManager.GetActiveScene().name == "6Tower2") // If current scene is the Level4 scene
			{
				if (gameObject.name == "CheckPoint1" && furthestAlong == 1)
				{
					checkPoint1Active = true;
					checkPoint2Active = false;
					checkPoint3Active = false;
					checkPoint4Active = false;
					checkPoint5Active = false;
					checkPoint6Active = false;
					furthestAlong = 2;
				}
				else if (gameObject.name == "CheckPoint2" && furthestAlong == 2)
				{
					checkPoint1Active = false;
					checkPoint2Active = true;
					checkPoint3Active = false;
					checkPoint4Active = false;
					checkPoint5Active = false;
					checkPoint6Active = false;
					furthestAlong = 3;
				}
				else if (gameObject.name == "CheckPoint3" && furthestAlong == 3)
				{
					checkPoint1Active = false;
					checkPoint2Active = false;
					checkPoint3Active = true;
					checkPoint4Active = false;
					checkPoint5Active = false;
					checkPoint6Active = false;
					furthestAlong = 4;
				}
				else if (gameObject.name == "CheckPoint4" && furthestAlong == 4)
				{
					checkPoint1Active = false;
					checkPoint2Active = false;
					checkPoint3Active = false;
					checkPoint4Active = true;
					checkPoint5Active = false;
					checkPoint6Active = false;
					furthestAlong = 5;
				}
				else if (gameObject.name == "CheckPoint5" && furthestAlong == 5)
				{
					checkPoint1Active = false;
					checkPoint2Active = false;
					checkPoint3Active = false;
					checkPoint4Active = false;
					checkPoint5Active = true;
					checkPoint6Active = false;
					furthestAlong = 6;
				}
				else if (gameObject.name == "CheckPoint6" && furthestAlong == 6)
				{
					checkPoint1Active = false;
					checkPoint2Active = false;
					checkPoint3Active = false;
					checkPoint4Active = false;
					checkPoint5Active = false;
					checkPoint6Active = true;
				}
			}
        }
    }
}
