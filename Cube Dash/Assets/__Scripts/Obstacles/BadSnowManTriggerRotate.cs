using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSnowManTriggerRotate : MonoBehaviour
{
    public bool shouldRotate;

    private void Start()
    {
        shouldRotate = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            shouldRotate = true;
        }
    }
}
