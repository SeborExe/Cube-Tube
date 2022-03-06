using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        float pos = transform.position.z;

        CheckPointsStats.SetCurrentCheckPoint(pos);
    }

    public IEnumerator CheckPointCoroutine(float pos)
    {
        var player = FindObjectOfType<PlayerMovement>();

        player.enabled = false;
        yield return new WaitForEndOfFrame();

        player.transform.position = new Vector3(0, 2, pos);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);

        yield return new WaitForEndOfFrame();
        player.enabled = true;
        FindObjectOfType<GameManager>().gameHasEnded = false;
    }
}
