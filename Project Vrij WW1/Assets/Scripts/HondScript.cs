using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HondScript : MonoBehaviour
{
    public GameObject hond; //DE HOND
    private Rigidbody2D rb; //De Rigidbody2D van de hond

    public GameObject player; //De SPELER
    public Transform leash;
    public Transform disappearPoint; //Punt waarop hij verdwijnt, duhh.

    private Transform target; //De target waar hij heen wil.

    public float speed; //WalkSpeed
    public float runSpeed; //RunSpeed
    private float speedVariable; //InscriptVariable for speed

    public bool running; //Deze gaat aan als hij wegrent.

    Vector2 transformRight = new Vector2(); //Variables die zorgen dat hij om kan draaien.
    Vector2 transformLeft = new Vector2(); //Variables die zorgen dat hij om kan draaien.
    private MoveScript mS; //Het moveScript van de speler


    void Start()
    {
        running = false;
        rb = GetComponent<Rigidbody2D>();
        mS = player.GetComponent<MoveScript>();

        transformLeft = transform.localScale;
        transformLeft.x = (transform.localScale.x * -1);
        transformRight = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            speedVariable = speed;
            target = leash;
        }
        else if (running)
        {
            speedVariable = runSpeed;
            target = disappearPoint;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speedVariable * Time.deltaTime);

        if (Vector2.Distance(transform.position, disappearPoint.position) < 3f)
        {
            Destroy(hond.gameObject);
        }

        checkFlip();
    }

    void checkFlip()
    {
        if (mS.moveInput > 0)
        {
            transform.localScale = transformRight;
        }
        if (mS.moveInput < 0)
        {
            transform.localScale = transformLeft;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disappear"))
        {
            running = true;
        }
    }
}
