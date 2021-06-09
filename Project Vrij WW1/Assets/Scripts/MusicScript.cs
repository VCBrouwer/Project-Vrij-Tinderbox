using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    //normalWorld done
    //hondWeg
    //normalWorld
    //haluWorld
    //sleeperd
    //end

    //hond1 done
    //hond2 done
    //hond3 done
    // Start is called before the first frame update

    private bool firstSound;

    public float timer;
    public bool Timer(float time)
    {

        timer += Time.deltaTime;
        if (timer >= time)
        {
            timer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("normalWorld");
        firstSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstSound)
        {
            if(Timer(15))
            {
                FindObjectOfType<AudioManager>().StopSound("hond1");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Disappear")) { FindObjectOfType<AudioManager>().PlaySound("hondWeg"); FindObjectOfType<AudioManager>().StopSound("normalWorld"); Debug.Log("Switch"); }
        if (collision.CompareTag("Lichtje")) { FindObjectOfType<AudioManager>().PlaySound("normalWorld"); FindObjectOfType<AudioManager>().StopSound("hondWeg"); Debug.Log("Switch"); }
        if (collision.CompareTag("LichtjeUit")) { FindObjectOfType<AudioManager>().PlaySound("haluWorld"); FindObjectOfType<AudioManager>().StopSound("normalWorld"); Debug.Log("Switch"); }
        if (collision.CompareTag("SleeperdTrigger")) { FindObjectOfType<AudioManager>().PlaySound("sleeperd"); FindObjectOfType<AudioManager>().StopSound("haluWorld"); Debug.Log("Switch"); }
        if (collision.CompareTag("RatterTrigger")) { FindObjectOfType<AudioManager>().PlaySound("hond1"); firstSound = true; }
        if (collision.CompareTag("GasserTrigger")) { FindObjectOfType<AudioManager>().PlaySound("hond2"); }
        if (collision.CompareTag("SleeperdTrigger")) {FindObjectOfType<AudioManager>().PlaySound("hond3"); }
    }
}
