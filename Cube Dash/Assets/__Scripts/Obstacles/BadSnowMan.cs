using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSnowMan : MonoBehaviour
{
    [Header("Definiowane w panelu inspekcyjnym")]
    public Transform[] target;
    public float speed;
    public float startRotY = -90f;
    public float jumpForce = 300f;
    public float rotSpeed = 1f;

    [Header("Definiowane dynamicznie")]
    public Vector3 startPos;
    public Quaternion rot;
    int firstTime = 0;
    private int current;
    private bool rotate;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPos = transform.position;

        rot = Quaternion.Euler(0, startRotY, 0);
        transform.rotation = rot;

        Jump();
    }

    void FixedUpdate()
    {
        rotate = GetComponentInChildren<BadSnowManTriggerRotate>().shouldRotate;

        if (transform.position != target[current].position && !rotate)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }

        else
        {
            if (rotate)
            {
                transform.Rotate(0f, 90f * Time.deltaTime * rotSpeed, 0f);

                if (transform.rotation == Quaternion.Inverse(rot) || transform.rotation == Quaternion.Euler(0, startRotY + 360, 0) || transform.rotation == Quaternion.Euler(0, startRotY, 0))
                {
                    rotate = false;
                    GetComponentInChildren<BadSnowManTriggerRotate>().shouldRotate = false;
                    rot = transform.rotation;
                    current = (current + 1) % target.Length;
                }
            }
        }
    }

    IEnumerator BasicPositionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        transform.position = startPos;
        firstTime = 0;
    }

    private void Jump()
    {
        rb.AddForce(0, rb.mass * jumpForce, 0);
        Invoke("Jump", 2f);
    }
}
