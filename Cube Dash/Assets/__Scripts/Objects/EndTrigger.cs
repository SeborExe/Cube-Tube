using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    InnerTimer innerTimer;

    private void Start()
    {
        innerTimer = FindObjectOfType<InnerTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;

        gameManager.CompleteLevel();

        innerTimer.gameIsAcive = false;
    }
}
