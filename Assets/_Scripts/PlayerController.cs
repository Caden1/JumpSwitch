using UnityEngine;
using System.Collections;
using Prime31; // For access to CharacterController2D
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera; // Reference to the main camera

    // public variables can be changed in Unity.
    public float gravity = -35;
    public float walkSpeed = 3;
    public float jumpHeight = 2;
    public float timeBetweenShots = 0.5f;

    // For getting postions for OverlapAreaAll. Need the game object reference.
    public GameObject topLeftObject;
    public GameObject bottomRightObject;

    // For Projectile firing
    public Transform firePosition; // The position it fires from
    public GameObject yellowProjectile; // The yellow projectile itself
    public GameObject blackProjectile; // The black projectile itself

    private CharacterController2D controller; // variable controller accesses public CharacterController2D members
    private Animator animator; // variable animator accesses public AnimationController2D members

    // Set the postions of the objects to these.
    private Vector2 topLeftPosition;
    private Vector2 bottomRightPosition;

    // For dimension switching
    [HideInInspector]
    public bool inDarkDimension; // To tell what dimension we're currently in

    // For Platform Switching
    private int darkPlatformLayerMask;
    private int lightPlatformLayerMask;
    private Collider2D[] cacheDarkPlatformHitColliders;
    private Collider2D[] cacheLightPlatformHitColliders;

    // For all other dimension switching
    private int darkOtherLayerMask;
    private int lightOtherLayerMask;
    private Collider2D[] cacheDarkOtherHitColliders;
    private Collider2D[] cacheLightOtherHitColliders;

    // For delayed projectile firing
    private bool canShoot;

    // For CheckPoint
    private bool hitCheckPoint1;

	// For delayed warping
	private bool canWarp;
	// For Warping
	private KillZone killZone;
	// For the shooting animation
	private bool shootAnimation;
    //Facing direction
    private int direction; // The scale for the player is (8,8,1)!!!

	// For playing sound effects
	public float shootVolume = 0.5f;
	public AudioClip shootSound;
	public float jumpVolume = 0.5f;
	public AudioClip jumpSound;
	public float landVolume = 0.5f; // not implemented yet
	public AudioClip landSound; // not implemented yet
	public float respawnVolume = 0.5f;
	public AudioClip respawnSound;
	public float switchVolume = 0.5f;
	public AudioClip switchSound;
    public float deathVolume = 0.5f;
    public AudioClip deathSound;
    public float recallVolume = 0.5f;
    public AudioClip recallSound;
    AudioSource audio;

    [HideInInspector]
    public static bool respawnNotDeath = true; // For playing either the respawn or death animation when scene loads. Accessed and set to false in the KillZone script.

    // Use this for initialization
    void Start()
    {
        // Use controller to gain access to the public CharacterController2D members
        controller = gameObject.GetComponent<CharacterController2D>(); // initialize for access to CharacterController2D
        animator = GetComponent<Animator>(); // initialize for access to Animation Controller
        mainCamera.GetComponent<CameraFollow2D>().startCameraFollow(this.gameObject); // Will set the camera to start following the player

        topLeftPosition = topLeftObject.transform.position; // Position of top left object
        bottomRightPosition = bottomRightObject.transform.position; // Position of bottom right object

        inDarkDimension = true; // Start in dark dimension
        animator.SetBool("dDark", true);
        animator.SetBool("dLight", false);

        // Platforms
        darkPlatformLayerMask = 1 << LayerMask.NameToLayer("DarkDimensionPlatform"); // Holds int mask of dark dimension platform
        lightPlatformLayerMask = 1 << LayerMask.NameToLayer("LightDimensionPlatform"); // Holds int mask of light dimension platform

        // Other
        darkOtherLayerMask = 1 << LayerMask.NameToLayer("DarkDimension"); // Holds int mask of other dark dimension
        lightOtherLayerMask = 1 << LayerMask.NameToLayer("LightDimension"); // Holds int mask of other light dimension

        // Initial overlap of the map. Saves all the colliders. It's not dynamic, so these are used again in the DarkDimension and LightDimension functions.
        // Platforms
        cacheDarkPlatformHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, darkPlatformLayerMask); // Saves dark dimension platform hit coliiders
        cacheLightPlatformHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, lightPlatformLayerMask); // Saves light dimension platform hit colliders

        // Other
        cacheDarkOtherHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, darkOtherLayerMask); // Saves dark dimension other hit colliders
        cacheLightOtherHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, lightOtherLayerMask); // Saves light dimension other hit coliiders

        DarkDimension(true); // Start in dark dimension
        LightDimension(false);

        canShoot = true;

		canWarp = true;

		killZone = gameObject.GetComponent<KillZone> ();

		shootAnimation = true;

		// For playing sound effects
		audio = GetComponent<AudioSource>();

        if (respawnNotDeath == true)
        {
            audio.PlayOneShot(respawnSound, respawnVolume);
        }
        else
        {
            audio.PlayOneShot(deathSound, deathVolume);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // Gets the current velocity CharacterController2D script. Will gradually increase gravity as we fall, etc.
        Vector3 velocity = controller.velocity; // velocity is also a public variable in the CharacterController2D script

        velocity.x = 0; // Re-initialize to zero so player can stop

		if (canWarp == true) // Running stops when warping
		{
	        if (Input.GetAxis("Horizontal") < 0) // if it returns a number less than zero it's for moving left
	        {
	            velocity.x = -walkSpeed;
                direction = -8;

	            if (controller.isGrounded) // If player is on the ground
	            {
                    // Play Run animation
                    transform.localScale = new Vector3(direction, 8, 1);
                    animator.SetBool("move", true); // Same name as it is in the Animator
                   
                }
                
               
	        }
	        else if (Input.GetAxis("Horizontal") > 0) // if it returns a number greater than zero it's for moving right
	        {
	            velocity.x = walkSpeed;
                direction = 8;

	            if (controller.isGrounded) // If player is on the ground
	            {
                    // Play Run animation
                    transform.localScale = new Vector3(direction, 8, 1);
                    animator.SetBool("move", true); // Same name as it is in the Animator
            
                }
                
                 // Faces sprite to the Right
         
            }
            
		else if (canWarp == true && shootAnimation == true && controller.isGrounded)
		{
			// Play Idle animation
				// Same name as it is in the Animator
            animator.SetBool("move", false);
		}

		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (canWarp == true)
			{
                respawnNotDeath = true; // Set to true if respawning.
                canWarp = false;
			    animator.SetTrigger("warp"); // Same name as it is in the Animator
                audio.PlayOneShot(recallSound, recallVolume);
                StartCoroutine(WaitForWarp()); // Calls WaitForWarp function and waits
                //audio.PlayOneShot(respawnSound, respawnVolume);
            }	
		}
		// For firing projectile
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) // Return and Spacebar fire projectile
		{
			if (canShoot == true && shootAnimation == true)
			{
				shootAnimation = false;
				if (inDarkDimension == true) // In dark dimension
				{
					animator.SetTrigger("shoot"); // Same name as it is in the Animator
					audio.PlayOneShot(shootSound, shootVolume);
                }
				else if (inDarkDimension == false) // In light dimension
				{
					animator.SetTrigger("shoot"); // Same name as it is in the Animator
					audio.PlayOneShot(shootSound, shootVolume);
                }

				StartCoroutine(WaitForShoot()); // Calls WaitForShoot function and waits

                if (inDarkDimension == true)
                {
                    Instantiate(yellowProjectile, firePosition.position, firePosition.rotation); // Creates the projectile
                }
                else if (inDarkDimension == false)
                {
                    Instantiate(blackProjectile, firePosition.position, firePosition.rotation); // Creates the projectile
                }

				//Instantiate(projectile, firePosition.position, firePosition.rotation); // Creates the projectile
                canShoot = false;
				StartCoroutine(Waiting()); // Calls Waiting function and waits
			}
		}

        if (controller.isGrounded)
        {
            animator.SetBool("grounded", true);
        }
        else if (!controller.isGrounded) {
            animator.SetBool("grounded", false);
        }
        // controller.isGrounded returns true of the player is on the ground
        if (controller.isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))) // 'w' and up arrow will jump
        {
            audio.PlayOneShot(jumpSound, jumpVolume);

            animator.SetBool("grounded", false);            
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity); // Jump calculation provided by Prime31

            // Play Jump animation
           animator.SetTrigger("jump"); // Same name as it is in the Animator

            audio.PlayOneShot(jumpSound, jumpVolume);
        }
        
        velocity.y += gravity * Time.deltaTime; // Add gravity to y-direction velocity

        // Movement being applied to the player. the move() function is from the CharacterController2D script
        controller.move(velocity * Time.deltaTime); // Time.deltaTime removes inconsistency due to frame-rate
    }

    // Taking advantage of coroutines to wait for a certain amount of time
    public IEnumerator WaitForShoot()
	{
		yield return new WaitForSecondsRealtime(0.4f);
		shootAnimation = true;
	}

	// Taking advantage of coroutines to wait for a certain amount of time
	public IEnumerator WaitForWarp()
	{
		yield return new WaitForSecondsRealtime(0.75f);
		killZone.LoadScenesAndCheckpoints(); // LoadScenesAndCheckpoints function in the KillZone Script
        audio.PlayOneShot(respawnSound, respawnVolume);
        canWarp = true;
	}

    // Taking advantage of coroutines to wait for a certain amount of time
    IEnumerator Waiting()
    {
        yield return new WaitForSecondsRealtime(timeBetweenShots);
        canShoot = true;
    }

    // This function switches the dimensions. It's called in the ProjectileController script
    public void SwitchDimension()
    {
        if (inDarkDimension == true) // In dark dimension
        {
            LightDimension(true); // Activate light dimension
            DarkDimension(false); // Deactivate dark dimension
            animator.SetBool("dLight", true); //swap dimesnions for animator
            animator.SetBool("dDark", false);
            inDarkDimension = false; // Switch bool

            audio.PlayOneShot(switchSound, switchVolume);
        }
        else if (inDarkDimension == false) // In light dimension
        {
            DarkDimension(true); // Activate dark dimension
            LightDimension(false); // Deactivate light dimension
            animator.SetBool("dLight", false);
            animator.SetBool("dDark", true);
            inDarkDimension = true; // Switch bool

            audio.PlayOneShot(switchSound, switchVolume);
        }
    }

    private void DarkDimension(bool activeOrDeactive)
    {
        // For Platforms
        foreach (Collider2D el in cacheDarkPlatformHitColliders)
        {
            el.gameObject.SetActive(activeOrDeactive); // Will either activate or deactivate the dark dimension
        }

        // For Other
        foreach (Collider2D el in cacheDarkOtherHitColliders)
        {
            el.gameObject.SetActive(activeOrDeactive);
        }


        // Creates the area overlap and returns all the colliders on a certain layer in the area.
        // Might need to try using OverlapAreaNonAlloc if it's too inefficient.
        // If we have moving platforms it will save the last state it was in.
        cacheLightPlatformHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, lightPlatformLayerMask); // Saves light dimension hit colliders
        cacheLightOtherHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, lightOtherLayerMask); // Saves light dimension other hit coliiders
    }

    private void LightDimension(bool activeOrDeactive)
    {
        // For Platforms
        foreach (Collider2D el in cacheLightPlatformHitColliders)
        {
            el.gameObject.SetActive(activeOrDeactive); // Will either activate or deactivate the light dimension
        }

        // For Other
        foreach (Collider2D el in cacheLightOtherHitColliders)
        {
            el.gameObject.SetActive(activeOrDeactive);
        }

        // Creates the area overlap and returns all the colliders on a certain layer in the area.
        // Might need to try using OverlapAreaNonAlloc if it's too inefficient.
        // If we have moving platforms it will save the last state it was in.
        cacheDarkPlatformHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, darkPlatformLayerMask); // Saves dark dimension hit coliiders
        cacheDarkOtherHitColliders = Physics2D.OverlapAreaAll(topLeftPosition, bottomRightPosition, darkOtherLayerMask); // Saves dark dimension other hit colliders
    }

}
