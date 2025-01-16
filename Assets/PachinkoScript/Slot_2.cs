using UnityEngine;

public class Slot_2 : MonoBehaviour
{
    public int scoreValue = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(collision.gameObject);
        }
    }
}
