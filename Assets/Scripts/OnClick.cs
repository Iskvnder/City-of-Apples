using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public AudioClip click;
    public AudioClip hoverSound;
    // Start is called before the first frame update
    public void PlayButtonClickSound()
    {
        GetComponent<AudioSource>().clip = click;
        GetComponent<AudioSource>().Play();
    }
    public void PlayButtonHoverSound()
    {
        GetComponent<AudioSource>().PlayOneShot(hoverSound);
    }
}
