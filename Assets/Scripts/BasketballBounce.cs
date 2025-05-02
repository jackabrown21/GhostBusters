using UnityEngine;

public class BasketballBounce : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter()
    {
        GetComponent<AudioSource>().Play();
    }
}
