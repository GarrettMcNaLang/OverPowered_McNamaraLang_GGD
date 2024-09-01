using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //idea for moving back an forth
    //a coroutine that can be set to a specific amount of time before the player turns the other direction

    Collider2D enemyCollider;

    public float speed;

    public float forceApply;

    private float direction = -1;

    private bool changeDir;

    public float turnTime;

    Transform transform;

    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyCollider = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();

        transform = GetComponent<Transform>();   

    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }

    void FixedUpdate()
    {
        

        rb.velocity = new Vector2(speed * Time.deltaTime * direction, rb.velocity.y);
        


    }

   
    
}
