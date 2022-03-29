using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : MonoBehaviour
{
    [Header("Definiowane w inspektorze")]
    public float force = 2f;
    public float maxSpeed = 2000f;

    [Header("Definiowane dynamicznie")]
    PlayerMovement player;

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag != "Player") return;

        player = collision.gameObject.GetComponent<PlayerMovement>();

        while (player.speed < maxSpeed)
            player.speed += force;

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        Debug.Log(player.speed);
    }

    private void OnTriggerExit(Collider collision)
    {
        while (player.speed > player.BasicSpeed)
            player.speed -= force;

        Debug.Log(player.speed);
    }
}
