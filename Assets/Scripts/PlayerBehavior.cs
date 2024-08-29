using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    //floats for holding movement speed values
    [SerializeField]
    private float hSpeed = 0f;

    //amount of force for a jump
    [SerializeField]
    private float jumpforce = 0f;
    
    [SerializeField]
    private float gravity = 2f;

    //the layer of objects that will let the game know if the play can jump
    public LayerMask GroundMask;

    //a bool that is true when the player is on an object with the ground layer
    private bool IsOnFloor;
   
    //the rigidbody for the player character
    private Rigidbody2D rb;

    //the axis that will hold the values for horizontal movement (left and right)
    private float hAxis;

    //distance between player collider to the Floor layer
    public float DistanceToFloor = 0.1f;

    //axis for jump movement
    private float jAxis;


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

        jAxis = Input.GetAxisRaw("Jump") * jumpforce;
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
        // var Force = new Vector2(hAxis,0) * Time.deltaTime;
        rb.velocity = new Vector2(hAxis, rb.velocity.y);
        
        //forces the rigidbody2D to move
        //rb.AddForce(Force);
    }

    //public bool isOnFloor()
    //{
        
    //}
    
}
