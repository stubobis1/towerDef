using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour
{

    public static SFX Instance;
    public AudioSource source;
    public AudioClip[] explostionSounds;
    public AudioClip[] throwSounds;
    public AudioClip BGM;
    
    // Use this for initialization
    void Start()
    {
        source = source == null ? this.GetComponent<AudioSource>() : source;
        Instance = this;
    }

    public void Explode()
    {
        source.PlayOneShot(explostionSounds[Random.Range(0,explostionSounds.Length)]);
    }
    public void Throw()
    {
        source.PlayOneShot(throwSounds[Random.Range(0,throwSounds.Length)]);
    }
}
