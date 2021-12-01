using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    AudioSource musica;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        musica = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!musica.isPlaying)
        {
            musica.clip = clip;
            musica.Play();
        }
    }
}
