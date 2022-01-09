using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;

    public int MapLength = 5;
    void Update()
    {
        scoreText.text = (player.position.z / MapLength).ToString("0") + '%';

    }
}
