using UnityEngine;
using System.Collections;

public class CameraSizeBigger : MonoBehaviour
{
    public Camera mainCamera; // Reference to the main camera
    public float cameraNewSize = 12;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // When the collider is collided with
        {
            mainCamera.orthographicSize = cameraNewSize;
        }
    }
}
