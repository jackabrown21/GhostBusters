using UnityEngine;

public class ToggleLight : MonoBehaviour
{

    public Material EmissiveMaterial; // Reference to the emissive material
    public Material NonEmissiveMaterial; // Reference to the non-emissive material
    public Light lightSource; // Reference to the light source

    public void ToggleLightSource()
    {
        if (lightSource != null)
        {
            lightSource.enabled = !lightSource.enabled; // Toggle the light source
            if (lightSource.enabled)
            {
                // If the light is on, set the emissive material
                gameObject.GetComponent<Renderer>().material = EmissiveMaterial;
            }
            else
            {
                // If the light is off, set the non-emissive material
                gameObject.GetComponent<Renderer>().material = NonEmissiveMaterial;
            }
        }
    }
}
