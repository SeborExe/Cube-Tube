using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBlock : MonoBehaviour
{
    [Header("Definiowane w inspektorze")]
    public float force = 2f;
    public float distance = 1f;

    [Header("Definiowane dynamicznie")]
    PlayerMovement player;

    private void OnCollisionStay(Collision collision)
    {
        player = collision.gameObject.GetComponent<PlayerMovement>();
        player.speed += force;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        Debug.Log(player.speed);
    }

    private void OnCollisionExit(Collision collision)
    {
        player.speed = 2500;
        Debug.Log(player.speed);
    }
}
