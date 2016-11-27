using UnityEngine;
using System.Collections;

public class ProjectileAnimation : MonoBehaviour
{
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("shootYellow", true);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
