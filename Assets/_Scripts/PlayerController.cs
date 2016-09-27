using UnityEngine;
using System.Collections;
using Prime31; // For access to CharacterController2D

public class PlayerController : MonoBehaviour
{
    public GameObject mainCamera; // Reference to the main camera

    // public variables can be changed in Unity.
    public float gravity = -35; 
    public float walkSpeed = 3;
    public float jumpHeight = 2;

    private CharacterController2D controller; // variable controller accesses public CharacterController2D members
    private AnimationController2D animator; // variable animator accesses public AnimationController2D memebers


    // Use this for initialization
    void Start ()
    {
        // Use controller to gain access to the public CharacterController2D members
        controller = gameObject.GetComponent<CharacterController2D>(); // initialize for access to CharacterController2D
        animator = gameObject.GetComponent<AnimationController2D>(); // initialize for access to AnimationController2D
        mainCamera.GetComponent<CameraFollow2D>().startCameraFollow(this.gameObject); // Will set the camera to start following the player
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Gets the current velocity CharacterController2D script. Will gradually increase gravity as we fall, etc.
        Vector3 velocity = controller.velocity; // velocity is also a public variable in the CharacterController2D script

        velocity.x = 0; // Re-initialize to zero so player can stop

        if (Input.GetAxis("Horizontal") < 0) // if it returns a number less than zero it's for moving left
        {
            velocity.x = -walkSpeed;

            if (controller.isGrounded) // If player is on the ground
            {
                // Play Run animation
                animator.setAnimation("Run"); // Same name as it is in the Animator
            }
            animator.setFacing("Left"); // Faces sprite to the left
        }
        else if (Input.GetAxis("Horizontal") > 0) // if it returns a number greater than zero it's for moving right
        {
            velocity.x = walkSpeed;

            if (controller.isGrounded) // If player is on the ground
            {
                // Play Run animation
                animator.setAnimation("Run"); // Same name as it is in the Animator
            }
            animator.setFacing("Right"); // Faces sprite to the Right
        }
        else
        {
            // Play Idle animation
            animator.setAnimation("Idle"); // Same name as it is in the Animator
        }

        // Bug: Jump only works while player is moving

        // controller.isGrounded returns true of the player is on the ground
        if (controller.isGrounded && Input.GetAxis("Jump") > 0) // Jump only returns positive number. Activated by spacebar
        {
            velocity.y = Mathf.Sqrt(2f * jumpHeight * -gravity); // Jump calculation provided by Prime31

            // Play Jump animation
            animator.setAnimation("Jump"); // Same name as it is in the Animator
        }

        velocity.y += gravity * Time.deltaTime; // Add gravity to y-direction velocity

        // Movement being applied to the player. the move() function is from the CharacterController2D script
        controller.move(velocity * Time.deltaTime); // Time.deltaTime removes inconsistency due to frame-rate

    }
}
