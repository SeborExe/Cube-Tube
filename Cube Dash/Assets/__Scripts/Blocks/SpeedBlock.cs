using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : MonoBehaviour
{
    [Header("Definiowane w inspektorze")]
    public float maxSpeed = 2000f;
    public float timeToMaxSpeed = 10f;
    public float timeToMinSpeed = 5f;

    [Header("Definiowane dynamicznie")]
    PlayerMovement player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "Player") return;

        player = collision.gameObject.GetComponent<PlayerMovement>();
        player.speed = Mathf.Lerp(player.speed, maxSpeed, timeToMaxSpeed);

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag != "Player") return;

        player = collision.gameObject.GetComponent<PlayerMovement>();
        player.speed = Mathf.Lerp(player.speed, player.BasicSpeed, timeToMinSpeed);
    }
}
