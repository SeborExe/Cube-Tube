using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRotating : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, Time.timeSinceLevelLoad * 60f, 0f);
    }
}
