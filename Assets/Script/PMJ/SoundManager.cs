using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound")]
    public AudioSource bgmPlayer;
    public AudioSource[] sfxPlayer;
    public AudioClip[] sfxClip;

    public enum Sfx { SClick }
    // Start is called before the first frame update
    void Start()
    {
        var soundManager = FindObjectsOfType<SoundManager>();
        if(soundManager.Length == 1)  DontDestroyOnLoad(gameObject);
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop()
    {
        sfxPlayer[0].clip = sfxClip[0];
        sfxPlayer[0].Play();
    }
}
