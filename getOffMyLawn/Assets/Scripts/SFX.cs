using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour
{

    public static SFX Instance;
    public AudioSource source;
    public AudioClip explostionSound;
    // Use this for initialization
    void Start()
    {
        source = source == null ? this.GetComponent<AudioSource>() : source;
        Instance = this;
    }

    public void Explode()
    {
        source.PlayOneShot(explostionSound);
    }
}
