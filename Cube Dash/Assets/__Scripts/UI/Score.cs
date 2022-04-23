using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    PlayerMovement player;
    public Text scoreText;

    public int MapLength = 5;

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player != null)
            scoreText.text = (player.transform.position.z / MapLength).ToString("0") + '%';
    }
}
