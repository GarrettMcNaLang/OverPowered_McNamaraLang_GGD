using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKiller : MonoBehaviour
{
    public delegate void AttackEvent(float force, Vector2 knockback);

    public event AttackEvent attackEvent;

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var PlayerCollider = GetComponentInParent<Transform>();

        Vector2 dirVector = (PlayerCollider.position - collision.transform.position).normalized;

        

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player has made contact with enemy" +
                "Initiating attack event");

            attackEvent(5, dirVector);
            //if (dirVector < 0)
            //    attackEvent(5, -1);
            //else if (dirVector > 0)
            //attackEvent(5, 1);
            
            
            
        }
    }
}
