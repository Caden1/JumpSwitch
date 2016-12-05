using UnityEngine;
using System.Collections;

public class CameraSizeSmaller : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera

    private float cameraOriginalSize;

    // Use this for initialization
    void Start ()
    {
        cameraOriginalSize = mainCamera.orthographicSize; // Gets the starting size of the main camera
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // When the collider is collided with
        {
            mainCamera.orthographicSize = cameraOriginalSize;
        }
    }
}
