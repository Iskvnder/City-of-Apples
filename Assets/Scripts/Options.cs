using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer; 
    // Start is called before the first frame update
    //public void SetVolume (float volume)
    //{
    //    audioMixer.SetFloat("Volume", volume);
    //}

    public void ResetProgress() {
        SaveData.LoadFile();
        SaveData.currentLevel = 1;
        SaveData.starterHit = true;
        SaveData.SaveFile();
    }
}
