using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private SkinManager skinManager;

    public float speed = 1000f;
    public float movementSpeed = 500f;

    private float ScreenWidth;
    public float BasicSpeed;
    public bool firstTime = true;

    private Vector3 startRotation;
    void Awake()
    {
        ScreenWidth = Screen.width;

        startRotation = transform.rotation.eulerAngles;

        if (firstTime)
            GameManager.S.SavePlayerSettings(skinManager.GetSelectedSkin().material, speed);

        GameManager.S.InitialPlayer();

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
    }

    private void RunCharacter(float horizontalInput)
    {
        rb.AddForce(movementSpeed * Time.deltaTime * horizontalInput, 0, 0, ForceMode.VelocityChange);
    }
}
