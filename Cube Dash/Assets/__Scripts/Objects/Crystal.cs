using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public bool Active = true;
    void Update()
    {
        transform.rotation = Quaternion.Euler(-82f, -90f, Time.timeSinceLevelLoad * 60f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" || !Active) return;

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;
        Active =  false;
        FindObjectOfType<CrystalCounter>().UpdateCrystalCounterText();
    }
}
