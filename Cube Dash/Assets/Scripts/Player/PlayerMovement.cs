using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private SkinManager skinManager;

    public float speed = 1000f;
    public float movementSpeed = 500f;
    float maxPosition = 6.45f;

    private float ScreenWidth;
    public float BasicSpeed;

    private Vector3 startRotation;
    void Start()
    {
        ScreenWidth = Screen.width;
        startRotation = transform.rotation.eulerAngles;
        BasicSpeed = speed;

        GetComponent<MeshRenderer>().material = skinManager.GetSelectedSkin().material;
        StartCoroutine(FindObjectOfType<InnerTimer>().TimerCoroutine());
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

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

        //if (transform.position.x >= maxPosition)
        //{
        //    transform.position = new Vector3(maxPosition, transform.position.y, transform.position.z);
        //}

        //if (transform.position.x <= -maxPosition)
        //{
        //    transform.position = new Vector3(-maxPosition, transform.position.y, transform.position.z);
        //}
    } 

    private void RunCharacter(float horizontalInput)
    {
        rb.AddForce(movementSpeed * Time.deltaTime * horizontalInput, 0, 0, ForceMode.VelocityChange);
    }
}
