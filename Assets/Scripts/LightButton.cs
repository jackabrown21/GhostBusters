using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class LightButton : MonoBehaviour
{
    public float deadTime = 0.5f; // Time before the button can be pressed again
    private bool _deadTimeActive = false;

    public UnityEvent onPressed;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive)
        {
            onPressed?.Invoke();
            audioSource.Play();
            Debug.Log("Button Pressed");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !_deadTimeActive)
        {
            StartCoroutine(WaitForDeadTime());
            Debug.Log("Button Released");
            StartCoroutine(WaitForDeadTime());
        }
    }

    IEnumerator WaitForDeadTime()
    {
        _deadTimeActive = true;
        yield return new WaitForSeconds(deadTime);
        _deadTimeActive = false;
    }



}
