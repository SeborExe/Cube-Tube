using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 1000f;
    public float movementSpeed = 500f;

    private float ScreenWidth;

    public bool lockX, lockY, lockZ;
    private Vector3 startRotation;
    void Start()
    {
        ScreenWidth = Screen.width;
        startRotation = transform.rotation.eulerAngles;
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //if (rb.position.y < -1f)
        //    FindObjectOfType<GameManager>().EndGame();

        #if UNITY_EDITOR
            RunCharacter(Input.GetAxis("Horizontal"));
        #endif
    }

    private void Update()
    {
        int i = 0;

        while (i <Input.touchCount)
        {
            if (Input.GetTouch (i).position.x > ScreenWidth / 2)
            {
                RunCharacter(1f);
            }

            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                RunCharacter(-1f);
            }

            i++;
        }

        //Vector3 newRotation = transform.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(
        //    lockX ? startRotation.x : newRotation.x,
        //    lockY ? startRotation.y : newRotation.y,
        //    lockZ ? startRotation.z : newRotation.z
        //);
    }

    private void RunCharacter(float horizontalInput)
    {
        rb.AddForce(movementSpeed * Time.deltaTime * horizontalInput, 0, 0, ForceMode.VelocityChange);
    }
}
