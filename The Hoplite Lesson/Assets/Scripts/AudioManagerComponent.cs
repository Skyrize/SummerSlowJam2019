using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerComponent : MonoBehaviour
{
    private Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();
    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i != transform.childCount; i++) {
            sounds[transform.GetChild(i).name] = transform.GetChild(i).GetComponent<AudioSource>();
        }
        
    }
    void Start()
    {
    }

    public AudioSource GetSound(string sound)
    {
        return sounds[sound];
    }
    public void PlaySoundDelayed(string sound, float delay)
    {
        sounds[sound].PlayDelayed(delay);
    }
    public void PlaySound(string sound)
    {
        sounds[sound].Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
