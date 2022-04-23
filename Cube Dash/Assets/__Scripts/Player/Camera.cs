using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    public Vector3 offset;

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
