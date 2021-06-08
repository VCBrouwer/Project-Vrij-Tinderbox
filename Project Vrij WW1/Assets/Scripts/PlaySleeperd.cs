using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySleeperd : MonoBehaviour
{
    [SerializeField] private Animator mySleeperdController;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        mySleeperdController.SetBool("PlaySleeperd2", true);
    }
}
