using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    CrystalCounter crystalCounter;

    public bool Active = true;

    private void Start()
    {
        crystalCounter = FindObjectOfType<CrystalCounter>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(-82f, -90f, Time.timeSinceLevelLoad * 60f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" || !Active) return;

        var renderer = GetComponent<Renderer>();
        renderer.enabled = false;
        Active =  false;
        crystalCounter.UpdateCrystalCounterText();
    }
}
