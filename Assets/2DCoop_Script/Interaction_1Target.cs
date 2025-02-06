using UnityEngine;

public class Interaction_1Target : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] float openSpeed = 3f;
    [SerializeField] Vector2 openOffset = new Vector2(0, 2f);

    private Vector2 originalPosition;
    private bool isOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            transform.position = Vector2.MoveTowards(transform.position, originalPosition + openOffset, openSpeed * Time.deltaTime);
        }
    }

    public void Open()
    {
        isOpen = true;
        GetComponent<Collider2D>().enabled = false;
    }
}
