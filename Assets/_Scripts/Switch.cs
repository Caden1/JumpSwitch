using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	private Animator animator;

	public GameObject[] switches;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();
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
