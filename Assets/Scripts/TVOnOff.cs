using UnityEngine;
using UnityEngine.Video;

public class TVOnOff : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Material emmissiveMaterial;
    public Material nonEmmissiveMaterial;

    public void turnOnOff()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
            gameObject.GetComponent<Renderer>().material = nonEmmissiveMaterial;

        }
        else
        {
            videoPlayer.Play();
            gameObject.GetComponent<Renderer>().material = emmissiveMaterial;
        }

    }
}
