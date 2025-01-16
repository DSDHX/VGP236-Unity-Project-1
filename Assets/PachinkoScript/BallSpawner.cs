using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject ballPrefab;
    public float moveSpeed = 5f;
    public float xMin = -3f;
    public float xMax = 3f;
    public float yPosition = 4.5f;

    // Update is called once per frame
    void Update()
    {
        MoveSpawner();
        SpawnBall();
    }

    void MoveSpawner()
    {
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + move, xMin, xMax), yPosition, 0);
    }

    void SpawnBall()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ballPrefab, transform.position, Quaternion.identity);
        }
    }
}
