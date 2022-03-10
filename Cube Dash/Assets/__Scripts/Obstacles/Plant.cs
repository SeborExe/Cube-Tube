using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Attack", 8f);
    }

    void Attack()
    {
        anim.SetTrigger("attack");
        Invoke("Attack", 8f);
    }

}
