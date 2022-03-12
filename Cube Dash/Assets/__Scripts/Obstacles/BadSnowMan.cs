using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSnowMan : MonoBehaviour
{
    [Header("Definiowane w panelu inspekcyjnym")]
    public Transform[] target;
    public float speed;
    public float startRotY = -90f;

    [Header("Definiowane dynamicznie")]
    public Vector3 pos;
    public Quaternion rot;
    int firstTime = 0;
    private int current;
    private bool rotate;

    private void Start()
    {
        pos = transform.position;
        rotate = false;

        rot = Quaternion.Euler(0, startRotY, 0);
        transform.rotation = rot;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (firstTime == 0)
        {
            StartCoroutine(BasicPositionCoroutine());
            firstTime = 1;
        }
    }

    void FixedUpdate()
    {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }

        else
        {
            rotate = true;

            if (rotate)
            {
                transform.Rotate(0f, 90f * Time.deltaTime, 0f);

                if (transform.rotation == Quaternion.Inverse(rot) || transform.rotation == Quaternion.Euler(0, startRotY + 360, 0) || transform.rotation == Quaternion.Euler(0, startRotY, 0))
                {
                    rotate = false;
                    rot = transform.rotation;
                    current = (current + 1) % target.Length;
                }
            }
        }
    }

    IEnumerator BasicPositionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        transform.position = pos;
        firstTime = 0;
    }
}
