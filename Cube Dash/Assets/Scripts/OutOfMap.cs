using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            FindObjectOfType<GameManager>().restartDelay = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
