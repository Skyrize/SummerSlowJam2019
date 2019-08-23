using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerComponent : MonoBehaviour
{
    private Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i != transform.childCount; i++) {
            sounds[transform.GetChild(i).name] = transform.GetChild(i).GetComponent<AudioSource>();
        }
        sounds["GameBeginMusic"].Play();
        sounds["GameMusic"].PlayDelayed(sounds["GameBeginMusic"].clip.length);
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
