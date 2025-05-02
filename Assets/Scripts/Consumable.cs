using UnityEngine;

public class Consumable : MonoBehaviour
{

    [SerializeField] GameObject[] portions;
    [SerializeField] int index = 0;
    AudioSource _audioSource;
    public bool IsFinished => index == portions.Length;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        setVisuals();

    }

    void OnValidate()
    {
        setVisuals();
    }

    [ContextMenu("Consume")]

    public void Consume()
    {
        if (!IsFinished)
        {
            _audioSource.Play();
            index++;
            setVisuals();
        }
    }

    void setVisuals()
    {
        for (int i = 0; i < portions.Length; i++)
        {
            if (i == index)
            {
                portions[i].SetActive(true);
            }
            else
            {
                portions[i].SetActive(false);
            }
        }
    }



}
