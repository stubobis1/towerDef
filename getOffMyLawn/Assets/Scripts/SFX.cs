using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour
{

    public static SFX Instance;
    public AudioSource source;
    public AudioClip[] explostionSounds;
    public AudioClip[] throwSounds;
    public AudioClip[] moneySounds;
    public AudioClip BGM;
    public AudioClip[] nopeSounds;
    
    // Use this for initialization
    void Start()
    {
        source = source == null ? this.GetComponent<AudioSource>() : source;
        Instance = this;
        SFX.Instance.source.PlayOneShot(SFX.Instance.BGM);
    }

    public void Explode()
    {
        source.PlayOneShot(explostionSounds[Random.Range(0,explostionSounds.Length)]);
    }
    public void Throw()
    {
        source.PlayOneShot(throwSounds[Random.Range(0,throwSounds.Length)]);
    }
    public void ChaChing()
    {
        source.PlayOneShot(moneySounds[Random.Range(0,moneySounds.Length)]);
    }
    public void Nope()
    {
        source.PlayOneShot(nopeSounds[Random.Range(0,nopeSounds.Length)]);
    }
}
