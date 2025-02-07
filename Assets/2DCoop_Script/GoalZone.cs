using UnityEngine;

public class GoalZone : MonoBehaviour
{
    private int playerCount = 0;
    private int totalPlayer = 4; // two collsion box for each player

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            playerCount++;
            Debug.Log("Win" + playerCount);
            if (playerCount == totalPlayer)
            {
                GameManager.instance.WinGame();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            playerCount--;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
