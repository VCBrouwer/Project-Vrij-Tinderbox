using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlaySound("end");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
