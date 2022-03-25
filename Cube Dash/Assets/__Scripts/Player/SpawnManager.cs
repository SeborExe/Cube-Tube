using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager S;

    public GameObject playerPrefab;

    private Material playerMat;
    private float playerSpeed;

    private void Awake()
    {
        S = this;

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

        if (FindObjectOfType<PlayerMovement>() == null)
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 2, pos), Quaternion.Euler(0, 0, 0));
            player.GetComponent<PlayerDeadMeshDestroy>().enabled = false;
            InitialPlayer();
            FindObjectOfType<Camera>().FindPlayer();

            player.GetComponent<PlayerDeadMeshDestroy>().enabled = true;
            FindObjectOfType<GameManager>().gameHasEnded = false;
        }
    }

    public void SavePlayerSettings(Material material, float speed)
    {
        playerMat = material;
        playerSpeed = speed;
        FindObjectOfType<PlayerMovement>().firstTime = false;
    }

    public void InitialPlayer()
    {
        var player = FindObjectOfType<PlayerMovement>();
        player.speed = playerSpeed;

        player.GetComponent<MeshRenderer>().material = playerMat;
    }
}
