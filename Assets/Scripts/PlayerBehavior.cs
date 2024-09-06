using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private GameManager _gameManager;

    JumpOnEnemy _jumpOnEnemy;
    AttackKiller _attackKiller;

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

    //collider for the player to detect events with enemies
    Collider2D PlayerCollider;
   
    //the rigidbody for the player character
    private Rigidbody2D rb;

    //the axis that will hold the values for horizontal movement (left and right)
    private float hAxis;

    //distance between player collider to the Floor layer
    public float DistanceToFloor = 0.1f;

    //this will represent the size of the vector2 of the player 
    //character's position
    public Vector2 BoxSize;

    //bool for checking if player is jumping
    private bool isJumping;

    private bool isAttacking;

    public GameObject attackfield;

    
    //function for attacking enemies

    // Start is called before the first frame update
    void Start()
    {
        //input axis' for movement
        
        //Reference to 2D rigidbody
        rb = GetComponent<Rigidbody2D>();

        //Reference to 2D collider

        PlayerCollider = GetComponent<Collider2D>();

        _gameManager = GameObject.Find("GM").GetComponent<GameManager>();

        _jumpOnEnemy = GameObject.Find("JumpKiller").GetComponent<JumpOnEnemy>();

        _attackKiller = attackfield.GetComponent<AttackKiller>();

        _jumpOnEnemy.jumpEvent += GoombaPropel;

        

        _attackKiller.attackEvent += HammerDown;

        attackfield.SetActive(false);
        
    }

    void Update()
    {
        //checks every frame for horizontal input (A,D or left arrow, right arrow)
        hAxis = Input.GetAxisRaw("Horizontal");
        //takes the axis for jumping, holding a bool for if the player is
        //pressing the space bar.
        isJumping |= Input.GetButtonDown("Jump");

        //checks if player is pressing the left mouse button

        isAttacking |= Input.GetMouseButtonDown(0);
        
    }
    //the FixedUpdate function is best for rigidbody
    //based movements
    void FixedUpdate()
    {
        if(isAttacking)
        {
            attackfield.SetActive(true);

            isAttacking = false;
        }
       
        //new info: create a raycast if the player is on the floor.

        //if the raycast (which is like 0.1), detects the floor, then the player will
        //move through the velocity property

        //if the player is in the air, such from jumping or is forced away by an
        //enemy, then applied force will be used to move the player character
        //value for the movement and it's speed

        //a vector2 that allows the player to move at a 
        //consistent framerate

        //This is what I am using for now to separate ground movement
        //and in the air movement

        //however

        if(isOnFloor())
        {
            rb.velocity = new Vector2(hAxis * hSpeed, rb.velocity.y);

            
        }
        
        


        //if the isonFloor method returns true and the
        //player has pressed the space bar (isJumping, vertical force to
        //the character to simulate a jump

        //Debug.Log("Is the player touching the floor" + isOnFloor());
        //Debug.Log("Did the player press the space key" + isJumping);

        if (isJumping && isOnFloor())
        {
            rb.AddForce(Vector2.up * jumpforce * Time.deltaTime, ForceMode2D.Force);
            
            //Insert here A & D keys being used to addforce and horizontal movement
            //in air
            
        }
        isJumping = false;

    }

    //the following method is what will check if the player is touching the floor,
    //which is any gameObjects that possess the Floor layer. This will
    //help ensure the player is only able to jump once, and will allow the player
    //to transition between moving on the ground (which is constant due to movement
    //being controlled by the velocity property), and moving through addforce,
    //in order to create variable movement when interacting with enemies
    public bool isOnFloor()
    {
        //parameters in order:
        //transform component of attached object
        //size of the transform
        //the angle of the box
        //the direction of the vector that is the transform component
        //the maximum distance the box should be casted
        //the colliders on this layermask needs to be checked for
        if(Physics2D.BoxCast(transform.position, BoxSize, 0, 
            -transform.up, DistanceToFloor, GroundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //this method will allow the programmer to physically manipulate
    //the vector2 that represents the box that will detect collisions ith
    //the layermask
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * DistanceToFloor, BoxSize);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _gameManager.PlayerHP -= 1;
        }
    }

    private void GoombaPropel(float knockback)
    {
        rb.AddForce(Vector2.up * knockback * Time.deltaTime, ForceMode2D.Force);
        Debug.Log("Player should have been forced up");
    }

    private void HammerDown(float knockback, Vector2 direction)
    {
        var force = knockback * direction;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    
}
