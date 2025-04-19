using UnityEngine;

public class PlayMusic : MonoBehaviour
{

    public AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onOff()
    {
        if (music.isPlaying)
        {
            music.Pause();
        }
        else
        {
            music.Play();
        }
    }
}
