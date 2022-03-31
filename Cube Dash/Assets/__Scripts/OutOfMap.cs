using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfMap : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" || other.gameObject.tag == "Player")
        {
            GameManager.S.restartDelay = 0;
            GameManager.S.OutOfMapEndGame();
        }
    }
}
