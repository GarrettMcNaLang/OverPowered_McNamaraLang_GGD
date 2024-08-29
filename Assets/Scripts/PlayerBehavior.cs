using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    //floats for holding movement speed values
    [SerializeField]
    private float hSpeed = 0f;

    //how fast the player will jump
    [SerializeField]
    private float jumpforce = 0f;

    [SerializeField]
    private float gravity = 2f;

    LayerMask GroundMask;

   
    private Rigidbody2D rb;

    private float hAxis;

    //function for attacking enemies

    // Start is called before the first frame update
    void Start()
    {
        //input axis' for movement
        
        //Reference to 2D rigidbody
        rb = GetComponent<Rigidbody2D>();

        


        
    }

    void Update()
    {
        //checks every frame for horizontal input (A,D or left arrow, right arrow)
        hAxis = Input.GetAxisRaw("Horizontal") * hSpeed;


    }
    //the FixedUpdate function is best for rigidbody
    //based movements
    void FixedUpdate()
    {
        //new info: create a raycast if the player is on the floor.

        //if the raycast (which is like 0.1), detects the floor, then the player will
        //move through the velocity property

        //if the player is in the air, such from jumping or is forced away by an
        //enemy, then applied force will be used to move the player character
        //value for the movement and it's speed
        
        //a vector2 that allows the player to move at a 
        //consistent framerate
        var Force = new Vector2(hAxis,0) * Time.deltaTime;
        //forces the rigidbody2D to move
        rb.AddForce(Force);
    }
    
}
