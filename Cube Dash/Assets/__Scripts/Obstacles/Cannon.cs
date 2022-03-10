using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Definiowane w panelu inspekcyjnym")]
    public GameObject snowBallPrefab;
    public GameObject SmogParticle;
    public float shootFrequency;
    public float shootPower;
    public Vector3 pos;
    public Vector3 prefabSize = Vector3.one * 3f;
    public Vector3 particleStartPos;

    private float startTime;
    private Animator anim;
    private Transform parent;

    void Start()
    {
        anim = GetComponent<Animator>();
        startTime = Time.time;
        parent = transform;
    }

    private void Update()
    {
        if (Time.time >= startTime + shootFrequency)
        {
            ShootIsActive();
        }
    }

    public void ShootSnowBall()
    {
        var ball = Instantiate(snowBallPrefab);

        Smog();

        ball.GetComponent<Transform>().localScale = prefabSize;
        ball.transform.SetParent(parent);
        ball.transform.position = transform.position + pos;
        ball.GetComponent<Rigidbody>().velocity = Vector3.back * shootPower;
    }

    public void ShootIsActive()
    {
        anim.SetBool("shoot", true);
    }

    public void DesactiveShoot()
    {
        anim.SetBool("shoot", false);
        startTime = Time.time;
    }

    private void Smog()
    {
        var smog = Instantiate(SmogParticle);
        smog.transform.SetParent(parent);
        smog.transform.position = transform.position + particleStartPos;
    }
}
