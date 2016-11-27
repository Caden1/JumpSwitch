using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class PauseGame : MonoBehaviour
{
    public Transform canvas; // Assign the canvas in the Inspector.
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0; // Stops the time so the player can't keep playing while paused.
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1; // Set time back to normal.
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Loads the current scene.
        Time.timeScale = 1; // Set time back to normal. Time is still 0 after calling this function from the pause menu.
    }

    public void Exit()
    {
        Time.timeScale = 1; // Set time back to normal. Time is still 0 after calling this function from the pause menu.
        SceneManager.LoadScene("MainMenu"); // Loads the current scene.
    }
}
