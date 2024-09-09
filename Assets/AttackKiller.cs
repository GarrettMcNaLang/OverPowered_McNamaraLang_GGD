using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKiller : MonoBehaviour
{
    public delegate void AttackEvent(float force, Vector2 knockback);

    public event AttackEvent attackEvent;

    public float AttackForce;

    public float knockBackHeight;
   
    private void OnTriggerEnter2D(Collider2D coll)
    {
        var PlayerCollider = GetComponentInParent<Transform>();

        Vector2 dirVector = (PlayerCollider.position - coll.transform.position).normalized;

        dirVector += Vector2.up * knockBackHeight;
        
        Debug.LogFormat("directional Vector {0}", dirVector);
        if (coll.tag == "Enemy")
        {
            Debug.Log("Player has made contact with enemy" +
                "Initiating attack event");

            attackEvent(AttackForce, dirVector);
            //if (dirVector < 0)
            //    attackEvent(5, -1);
            //else if (dirVector > 0)
            //attackEvent(5, 1);
            
            
            
        }
    }
}
