using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip pickup;
    static AudioSource audioSrc;
    void Start()
    {
        pickup = Resources.Load<AudioClip>("Pickup");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Pickup":
                audioSrc.PlayOneShot(pickup);
                break;
        }
    }
}
