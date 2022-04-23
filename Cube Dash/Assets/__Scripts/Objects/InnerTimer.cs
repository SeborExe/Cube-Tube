using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerTimer : MonoBehaviour
{
    public int time = 0;
    public bool gameIsAcive = true;

    private void Start()
    {
        gameIsAcive = true;
    }
    public IEnumerator TimerCoroutine()
    {
        while(gameIsAcive)
        {
            time += 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
