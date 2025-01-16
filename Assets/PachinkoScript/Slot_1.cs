using UnityEngine;

public class Slot_1 : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(collision.gameObject);
        }
    }
}
