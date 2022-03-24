using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Animator anim;
    public float attackFrequency = 8f;
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Attack", attackFrequency);
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        Invoke("Attack", attackFrequency);
    }

}
