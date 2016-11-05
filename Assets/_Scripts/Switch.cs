using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
	public GameObject[] switches;

	// Use this for initialization
	void Start () 
	{
		switches = GameObject.FindGameObjectsWithTag("Switch");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile")
		{
			foreach (GameObject el in switches) 
			{
				el.GetComponent<Animator> ().SetTrigger ("isHit");
			}
		}
	}
}
