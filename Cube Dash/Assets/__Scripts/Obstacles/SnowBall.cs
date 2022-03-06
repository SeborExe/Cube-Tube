using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [Header("Definiowane dynamicznie")]
    private Transform trans;
    void Start()
    {
        trans = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        var scale = trans.localScale;

        scale *= 0.9997f;
        trans.localScale = scale;

        if (trans.localScale.x <= 0.2f)
        {
            //TODO: snow particles
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            //TODO: snow particles
            Destroy(gameObject);
        }
    }
}
