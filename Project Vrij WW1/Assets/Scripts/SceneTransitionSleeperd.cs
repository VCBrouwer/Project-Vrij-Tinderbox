using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionSleeperd : MonoBehaviour
{
    private bool canSceneTransition;
    void Start()
    {
        canSceneTransition = false;
    }

    void Update()
    {
        if (canSceneTransition)
        {
            if (Timer(7))
            {
                SceneManager.LoadScene(2); //deze '1' moet het nummer van de scene zijn waar je heen wilt
            }

        }
    }

    private float timer;
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


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canSceneTransition = true;
        }

    }
}

