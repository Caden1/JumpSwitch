using UnityEngine;
using System.Collections;

public class SaveGameCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // When the object is collided with
        {
            // Save to specific file depending on the player profile chosen.
            if (GameControl.playerProfile == 1)
            {
                GameControl.Save("/player1Info.dat"); 
            }
            else if (GameControl.playerProfile == 2)
            {
                GameControl.Save("/player2Info.dat"); 
            }
            else if(GameControl.playerProfile == 3)
            {
                GameControl.Save("/player3Info.dat"); 
            }
        }
    }
}
