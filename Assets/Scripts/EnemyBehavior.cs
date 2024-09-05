using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
   
    //idea for moving back an forth
    //a coroutine that can be set to a specific amount of time before the player turns the other direction

    Collider2D enemyCollider;

    public float speed;

    public float forceApply;

    Rigidbody2D rb;

    //public slots in the inspector to put two points that will be the boundaries for the enemy patrol
    public GameObject LBound;
    public GameObject RBound;
    //which position is the enemy at between the two points
    private Transform CurrentPoint;



    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();

        CurrentPoint = RBound.transform;

        
    }

    void FixedUpdate()
    {
        
        Vector2 point = CurrentPoint.position - transform.position;

       if(CurrentPoint == RBound.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
       else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == RBound.transform ) {

            CurrentPoint = LBound.transform;
            
            

        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5f && CurrentPoint == LBound.transform)
        {
            CurrentPoint = RBound.transform;
              
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(LBound.transform.position, 0.5f);
        Gizmos.DrawWireSphere(RBound.transform.position, 0.5f);
        Gizmos.DrawLine(LBound.transform.position, RBound.transform.position);  
    }

   

}
