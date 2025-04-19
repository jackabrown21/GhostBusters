using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Light lightSource; // Reference to the Light component
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void switchFlicked()
    {
        // Toggle the light on or off
        if (lightSource != null)
        {
            lightSource.enabled = !lightSource.enabled;
        }
        else
        {
            Debug.LogWarning("Light source is not assigned in the inspector.");
        }

        // Play the animation if it exists. Forward or backward based on the light state
        if (lightSource.enabled)
        {
            gameObject.GetComponent<Animator>().Play("switch", 0, 0.0f);
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("switchOn", 0, 1.0f);
        }


        //
    }
}
