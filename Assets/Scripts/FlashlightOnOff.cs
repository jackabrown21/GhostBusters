using UnityEngine;

public class FlashlightOnOff : MonoBehaviour
{

    public GameObject light1;
    public GameObject light2;
    public AudioSource sfx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnActivate()
    {
        light1.SetActive(!light1.activeSelf);
        light2.SetActive(!light2.activeSelf);
        sfx.Play();
    }
}
