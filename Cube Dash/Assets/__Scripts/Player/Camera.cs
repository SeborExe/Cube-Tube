using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (player != null)
            transform.position = player.position + offset;  
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
