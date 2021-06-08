using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRatter : MonoBehaviour
{
    [SerializeField] private Animator myRatterController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            myRatterController.SetBool("PlayRatter", true);
    }

}

