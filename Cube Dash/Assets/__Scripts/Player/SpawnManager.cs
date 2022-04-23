using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager S;

    public GameObject playerPrefab;

    Camera camera;
    [SerializeField] GameManager gameManager;

    PlayerMovement playerMovement;

    private Material playerMat;
    private float playerSpeed;

    private void Awake()
    {
        S = this;

    }

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        camera = FindObjectOfType<Camera>();
    }

    public void CheckPoint(float pos)
    {
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "corps")
            {
                Destroy(gameObj);
            }
        }

        if (playerMovement == null)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 2, pos), Quaternion.Euler(0, 0, 0));
            player.GetComponent<PlayerDeadMeshDestroy>().enabled = false;
            InitialPlayer();
            camera.FindPlayer();

            player.GetComponent<PlayerDeadMeshDestroy>().enabled = true;
            gameManager.gameHasEnded = false;
        }
    }

    public IEnumerator CheckPointCoroutine(float pos)
    {
        var player = FindObjectOfType<PlayerMovement>();

        player.enabled = false;
        yield return new WaitForEndOfFrame();

        player.transform.position = new Vector3(0, 2, pos);
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.speed = playerSpeed;

        yield return new WaitForEndOfFrame();
        player.enabled = true;
        GameManager.S.gameHasEnded = false;
        GameManager.S.restartDelay = 2f;
    }

    public void SavePlayerSettings(Material material, float speed)
    {
        playerMat = material;
        playerSpeed = speed;
        playerMovement.firstTime = false;
    }

    public void InitialPlayer()
    {
        var player = FindObjectOfType<PlayerMovement>();
        player.speed = playerSpeed;

        player.GetComponent<MeshRenderer>().material = playerMat;
    }
}
