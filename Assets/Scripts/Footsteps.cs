using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public AudioSource audioSource;
    public InputActionAsset inputsystem; // Reference to the "Move" action from the Input System

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.enabled = false; // Prevents the audio from playing automatically when the game starts

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = inputsystem.FindAction("Move").ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
