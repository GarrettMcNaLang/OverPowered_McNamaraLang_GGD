using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnEnemy : MonoBehaviour
{
    public delegate void JumpEvent(Vector2 VecArg);

    public event JumpEvent jumpEvent;

    public float GoombaForce;

    private Vector2 GoombaVec;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "WeakSpot")
        {
            //trigger a jump event where the player's rigibody2D
            //will be propelled in the opposite direction.
            GoombaVec = Vector2.up * GoombaForce;
            Debug.Log("Enemy has been stepped on, " +
                "initiating event...");
            jumpEvent(GoombaVec);
        }

        


    }

  
}
