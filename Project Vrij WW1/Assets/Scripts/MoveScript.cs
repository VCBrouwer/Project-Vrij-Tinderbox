using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    private float fastSpeed;
    [SerializeField]
    private float normalMoveSpeed;

    public float moveInput;

    Vector2 transformRight = new Vector2();
    Vector2 transformLeft = new Vector2();

    private Rigidbody2D rb;

    public GameObject NormalWorld;
    public GameObject HalluWorld;
    public GameObject Hond;
    public GameObject HondWeg;
    public GameObject MarshCamera;
    public GameObject NormalCamera;

    private bool runFaster;

    //lichtje
    public GameObject lichtje;

    //animatie
    public Animator animator;

    private bool canWalk;



    void Start()
    {
        normalMoveSpeed = moveSpeed;

        rb = GetComponent<Rigidbody2D>();

        //De variables zodat de sprite kan flippen
        transformLeft = transform.localScale;
        transformLeft.x = (transform.localScale.x * -1);
        transformRight = transform.localScale;

        canWalk = true;
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

        moveInput = Input.GetAxis("Horizontal");

        if (canWalk)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }


       


        //animatie
        if (runFaster && moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isWalking", false);
        }else if (!runFaster && moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isWalking", true);
        }
        if (!runFaster)
        {
            animator.SetBool("isRunning", false);
        }
        else if (runFaster)
        {
            animator.SetBool("isRunning", true);
        }

        //animator.SetFloat("isRunning", Mathf.Abs(moveSpeed)); //Hij zegt dat deze parameter niet besteed "Rennen"
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


        if (other.gameObject.CompareTag("MarshCamera"))
        {
            NormalCamera.gameObject.SetActive(false);
            MarshCamera.gameObject.SetActive(true);
        }

        //Lichtje
        if (other.gameObject.CompareTag("Lichtje"))
        {
            lichtje.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("LichtjeUit"))
        {
            lichtje.gameObject.SetActive(false);
        }




        if (other.CompareTag("Speed"))
        {
            runFaster = true;
        }
        if (other.CompareTag("Slow"))
        {
            runFaster = false;
        }
        if (other.CompareTag("Stop"))
        {
            canWalk = false;
        }
    }
}
