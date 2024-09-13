using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackKiller : MonoBehaviour
{
    public delegate void AttackEvent(Vector2 knockback);

    public event AttackEvent attackEvent;

    public float AttackForce;

    public float knockBackHeight;

    public Vector2 dirVector;

    //public float Direction;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerCollider = GetComponentInParent<Transform>();

        var PlayerRB = GetComponentInParent<Rigidbody2D>();

        //Direction = PlayerCollider.position.x - coll.transform.position.x;
        //new Vector2(1 * AttackForce * Direction, 1 * knockBackHeight);
        dirVector = (transform.position - collision.transform.position).normalized;

        dirVector.x *= AttackForce;
        dirVector.y *= knockBackHeight;

        if (dirVector.y < 0)
            dirVector.y *= -1;

        Debug.LogFormat("directional Vector {0}", dirVector);
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player has made contact with enemy" +
                "Initiating attack event");

            attackEvent(dirVector);
            //if (dirVector < 0)
            //    attackEvent(5, -1);
            //else if (dirVector > 0)
            //attackEvent(5, 1);
            
            
            
        }
    }
}
