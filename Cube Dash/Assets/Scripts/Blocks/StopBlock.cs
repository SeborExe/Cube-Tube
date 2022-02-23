using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBlock : MonoBehaviour
{
    [Header("Definiowane dynamicznie")]
    public float speed;
    bool PlayerIsOnBlock = false;
    Vector3 TouchStart;
    bool MakingGesture = false;

    bool GestuleIsMade = false;
    private float ScreenHeight;

    void Update()
    {
        if (PlayerIsOnBlock)
        {
            UpdateAction();

            if (Input.GetKeyDown(KeyCode.L) || GestuleIsMade)
            {
                PlayerActive();
                StartCoroutine(ActiveColliderCoroutine());
            }
        } else
        {
            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player") return;

        speed = collision.gameObject.GetComponent<PlayerMovement>().speed;

        collision.gameObject.GetComponent<PlayerMovement>().speed = 0;
        GetComponent<MeshCollider>().enabled = false;
        PlayerIsOnBlock = true;
    }

    void UpdateAction()
    {
        if (!MakingGesture && Input.GetMouseButtonDown(0))
            StartGesture();

        if (MakingGesture && Input.GetMouseButtonDown(0))
            CheckGesture();

        if (Input.GetMouseButtonUp(0))
            ResetGesture();
    }

    void StartGesture()
    {
        TouchStart = Input.mousePosition;
        MakingGesture = true;
    }

    void CheckGesture()
    {
        //var touchDelta = Input.mousePosition - TouchStart;
        //touchDelta /= Screen.dpi;

        //var angle = Vector2.SignedAngle(Vector3.up, touchDelta);

        /*
        if (touchDelta.magnitude < 1f)
        {
            Debug.Log("Za kr�tko!!");
            return;
        }
        */

        //if (-40f < angle && angle < 40f)
        //{
        //    GestuleIsMade = true;
        //    Debug.Log("Giga czad!");
        //}

        ScreenHeight = Screen.height;
        if (Input.GetTouch(0).position.y > ScreenHeight / 1.75f)
        {
            GestuleIsMade = true;
        }

        else
            return;

        MakingGesture = false;
    }

    void ResetGesture()
    {
        TouchStart = Vector3.zero;
        MakingGesture = false;
    }

    IEnumerator ActiveColliderCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<MeshCollider>().enabled = true;
    }

    public void PlayerActive()
    {
        FindObjectOfType<PlayerMovement>().speed = speed;
        PlayerIsOnBlock = false;
    }
}
