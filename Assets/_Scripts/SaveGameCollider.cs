using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; // Needed for Scene Manager functionality

public class SaveGameCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if ((GameControl.playerProfile == 1 && GameControl.beatGame1 == true) || (GameControl.playerProfile == 2 && GameControl.beatGame2 == true)
            || (GameControl.playerProfile == 3 && GameControl.beatGame3 == true)) // Player has beaten the game.
        {
            // Do Nothing
        }
        else // Save Progress
        {
            if (col.tag == "Player") // When the object is collided with
            {
                // Save to specific file depending on the player profile chosen.
                if (GameControl.playerProfile == 1)
                {
                    GameControl.hasData1 = true;
                    GameControl.Save("/player1Info.dat");
                }
                else if (GameControl.playerProfile == 2)
                {
                    GameControl.hasData2 = true;
                    GameControl.Save("/player2Info.dat");
                }
                else if (GameControl.playerProfile == 3)
                {
                    GameControl.hasData3 = true;
                    GameControl.Save("/player3Info.dat");
                }
            }
        }
    }
}
