using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionEind : MonoBehaviour
{
    
 

    void Update()
    {
       
            if (Timer(20))
            {
                SceneManager.LoadScene(4); //deze '1' moet het nummer van de scene zijn waar je heen wilt
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
