using UnityEngine;
using UnityEngine.Events;

public class Interaction_1 : MonoBehaviour
{
    public UnityEvent onSwitchActivated;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            ActivateSwitch();
        }
    }

    void ActivateSwitch()
    {
        onSwitchActivated.Invoke();

        GetComponent<Collider2D>().enabled = false;
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
