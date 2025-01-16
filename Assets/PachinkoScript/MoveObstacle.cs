using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveRange = 3.0f;
    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector3(Mathf.Sin(Time.time * moveSpeed) * moveRange, 0, 0);
    }
}
