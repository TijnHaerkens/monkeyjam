using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementp2 : MonoBehaviour
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


    [Header("jumping")]
    float playerHeight = 2f;
    public float dashpower = 5f;
    public float jumppower = 2f;



    public LayerMask wall;
    public LayerMask ground;

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
        }


        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.D))
        {
            dash = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dash = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (IsGrounded() == true)
            {
                Jump();
            }
            else if (hasDashedInAir == false)
            {
                hasDashedInAir = true;
                Jump();
            }
        }
        if (Input.GetKeyDown(jumpkey) && IsGrounded())
        {
            Sjump();
        }

    }
    private void FixedUpdate()
    {
        if (body.velocity.x >= maxspeed || body.velocity.x <= -maxspeed)
        {
            body.velocity = body.velocity.normalized * maxspeed;
        }

        body.AddForce(new Vector2(movementspeed * horizontalMovement, body.velocity.y));


    }
    void Jump()
    {
        if (dash == true)
        {

            body.AddForce(Vector2.right * dashpower, ForceMode2D.Impulse);
        }
        if (dash == false)
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
        Vector2 direction = Vector2.down;

        float distance = 3f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        if (hit.collider != null)
        {

            return true;
        }



        return false;
    }
}