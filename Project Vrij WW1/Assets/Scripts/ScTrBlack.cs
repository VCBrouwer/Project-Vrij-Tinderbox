using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScTrBlack : MonoBehaviour
{
    void Update()
    {
        if (Timer(3.5f))
        {
            SceneManager.LoadScene(3); //deze '1' moet het nummer van de scene zijn waar je heen wilt
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
}
