using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    [Header("Definiowane w inspektorze")]
    public float jumpForce = 1000f;

    [Header("Definiowane dynamicznie")]
    Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") return;

        rb = collision.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * jumpForce);
    }
}
