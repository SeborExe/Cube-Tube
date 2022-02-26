using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    public Vector3 pos;
    int firstTime = 0;

    private int current;

    private void Start()
    {
        pos = transform.position;
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
        else current = (current + 1) % target.Length;
    }

    IEnumerator BasicPositionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        transform.position = pos;
        firstTime = 0;
    }
}
