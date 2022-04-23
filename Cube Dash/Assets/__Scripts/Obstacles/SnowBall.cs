using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [Header("Definiowane w panelu inspekcyjnym")]
    [SerializeField]
    private GameObject snowParticle;
    [SerializeField]
    private Vector3 particleStartPos;
    [SerializeField]
    public GameObject SnowPoofEffect;

    [Header("Definiowane dynamicznie")]
    private Transform trans;
    private GameObject snowObj;

    void Start()
    {
        trans = GetComponent<Transform>();

        snowObj = Instantiate(snowParticle);
        snowObj.transform.position = transform.position + particleStartPos;
    }
    void FixedUpdate()
    {
        var scale = trans.localScale;
        snowObj.transform.position = transform.position;

        scale *= 0.999f;
        trans.localScale = scale;

        if (trans.localScale.x <= 0.2f)
        {
            Destroy(snowObj, 0.5f);

            Instantiate(SnowPoofEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Player")
        {
            Destroy(snowObj, 0.5f);

            Instantiate(SnowPoofEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
