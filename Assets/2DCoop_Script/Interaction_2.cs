using UnityEngine;
using UnityEngine.Events;

public class Interaction_2 : MonoBehaviour
{
    public UnityEvent onSwitchActivated;

    private bool canInteract;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.F))
        {
            ActivateSwitch();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canInteract = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            canInteract = false;
            player = null;
        }
    }

    void ActivateSwitch()
    {
        onSwitchActivated.Invoke();
        GetComponent<Collider2D>().enabled = false;
    }
}
