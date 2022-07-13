using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Rigidbody2D body;


    private float horizontalMovement;
    private float verticalMovement;
    private bool dash;
    private bool canDash;
    private bool hasDashedInAir = false;
    [Header("movement")]
    public float movementspeed = 10f;
    public float maxspeed = 20f;

    [Header("keybinds")]
    [SerializeField] KeyCode jumpkey = KeyCode.Space;
    [SerializeField] KeyCode akey = KeyCode.A;
    [SerializeField] KeyCode dkey = KeyCode.D;

    [Header("jumping")]
    float playerHeight = 2f;
   public float dashpower = 5f;
    public float jumppower = 2f;

    /*public Collider2D basketcollider;*/

    public LayerMask wall;
    public LayerMask ground;
    public LayerMask banana;
    public LayerMask Monkey;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

       if (IsGrounded())
        {
            hasDashedInAir = false;
            movementspeed = maxspeed;
        }

        if (IsGrounded() == false && hasDashedInAir == true)
        {
            movementspeed = 5;
        }else if (IsGrounded() == false && hasDashedInAir == false)
        {
            movementspeed = 10;
        }


        horizontalMovement = 0;









        if (Input.GetKey(KeyCode.D))
        {
            dash = true;
            
        }
        else if(Input.GetKey(KeyCode.A))
        {
            dash = false;
            
        }

        
        if (Input.GetKeyDown(jumpkey))
        {
            if (IsGrounded() == true)
            {
                Sjump();
            }else if(hasDashedInAir == false)
            {
                hasDashedInAir = true;
                Sjump();
            }
            
        }

    }
    private void FixedUpdate()
    {
        if (body.velocity.x >= maxspeed || body.velocity.x <= -maxspeed)
        {
            body.velocity = body.velocity.normalized * maxspeed;
        }


        if (Input.GetKey(akey))
        {
            transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
            horizontalMovement = -1;
        }
        if (Input.GetKey(dkey))
        {
            transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
            horizontalMovement = 1;
        }


    }
    void Jump()
    {
        if (dash == true)
        {
            
            body.AddForce(Vector2.right * dashpower, ForceMode2D.Impulse);
        } if (dash == false)
        {
            
            body.AddForce(Vector2.left * dashpower, ForceMode2D.Impulse);
        }
    }
    void Sjump()
    {
        body.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
    }
    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 positionMonkey = transform.position + new Vector3 (0,-1.2f,0);
        Vector2 direction = Vector2.down;

        float distance = 1.5f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        if (hit.collider != null)
        {
            
            return true;
        }

        RaycastHit2D hit1 = Physics2D.Raycast(positionMonkey, direction, distance -1f, Monkey);
        if (hit1.collider != null)
        {
            dash = false;
            return true;
        }

        return false;
    }
}