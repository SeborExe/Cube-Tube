using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : MonoBehaviour
{
    [Header("Definiowane w inspektorze")]
    public float maxSpeed = 2000f;
    public float acceleration = 200f;
    public float slowingDown = 250f;

    [Header("Definiowane dynamicznie")]
    PlayerMovement player;

    private bool stopBlockIsActive = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player") return;

        player = collision.gameObject.GetComponent<PlayerMovement>();
        stopBlockIsActive = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag != "Player") return;

        player = collision.gameObject.GetComponent<PlayerMovement>();
        stopBlockIsActive = false;
    }

    private void Update()
    {
        if (stopBlockIsActive)
        {
            if (player != null)
            {
                if (player.speed < maxSpeed)
                    player.speed += Time.deltaTime * acceleration;
            }
        }
        else if (!stopBlockIsActive)
        {
            if (player != null)
            {
                if (player.speed > player.BasicSpeed)
                    player.speed -= Time.deltaTime * slowingDown;
            }
        }
    }
}
