using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemy : MonoBehaviour
{
    public delegate void JumpEvent(float jumpforce);

    public event JumpEvent jumpEvent;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WeakSpot")
        {
            //trigger a jump event where the player's rigibody2D
            //will be propelled in the opposite direction.

            Debug.Log("Enemy has been stepped on, " +
                "initiating event...");
            jumpEvent(10);
        }

        


    }

  
}
