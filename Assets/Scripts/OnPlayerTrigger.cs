using UnityEngine;
using UnityEngine.Events;

public class OnPlayerTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UnityEvent onEnter;
    public UnityEvent onExit;

    private void OnTriggerEnter(Collider other)
    {
        onEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onExit.Invoke();
    }
}
