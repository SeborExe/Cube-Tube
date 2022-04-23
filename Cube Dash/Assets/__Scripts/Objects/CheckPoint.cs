using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        float pos = transform.position.z;

        CheckPointsStats.SetCurrentCheckPoint(pos);
    }
}
