using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    public UnityEvent disableBlocks;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        float pos = transform.position.z;
        disableBlocks?.Invoke();

        CheckPointsStats.SetCurrentCheckPoint(pos);
    }
}
