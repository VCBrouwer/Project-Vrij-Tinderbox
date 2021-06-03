using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed; 
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float checkRadius;

    private float moveInput;

    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private Transform groundCheck;

    Vector3 transformRight = new Vector2();
    Vector3 transformLeft = new Vector2();

    private Rigidbody2D rb;

    public GameObject NormalWorld;
    public GameObject HalluWorld;
    public GameObject Hond;
    public GameObject HondWeg;

    private bool runFaster;
    [SerializeField]
    private float fastSpeed;
    private float normalMoveSpeed;
    



    void Start() {
        normalMoveSpeed = moveSpeed;

        rb = GetComponent<Rigidbody2D>();

        //De variables zodat de sprite kan flippen
        transformLeft = transform.localScale;
        transformLeft.x = (transform.localScale.x * -1);
        transformRight = transform.localScale;
    }
    
 
    void FixedUpdate()
    {
        if (runFaster)
        {
         moveSpeed = fastSpeed;
        }
        else if (!runFaster)
        {
         moveSpeed = normalMoveSpeed;
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        checkFlip();
    }

    void checkFlip()
    {
        if (moveInput > 0)
        {
            transform.localScale = transformRight;
        }
        if (moveInput < 0)
        {
            transform.localScale = transformLeft;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PTSSTrig"))
        {

            NormalWorld.gameObject.SetActive(false);
            HalluWorld.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("NormalTrig"))
        {

            NormalWorld.gameObject.SetActive(true);
            HalluWorld.gameObject.SetActive(false);


        }
        if (other.gameObject.CompareTag("HondWeg"))
        {
            Hond.gameObject.SetActive(false);
            HondWeg.gameObject.SetActive(true);
        }

        if (other.CompareTag("Speed"))
        {
            runFaster = true;
        }
        if (other.CompareTag("Slow"))
        {
            runFaster = false;
        }

    }
  
        
    }
