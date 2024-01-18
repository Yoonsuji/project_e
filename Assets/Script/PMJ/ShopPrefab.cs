using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Shop Click", menuName = "Scriptable Object/Sound Data", order = int.MaxValue)]
public class ShopPrefab : ScriptableObject
{
    public AudioSource sfxPlayer;
    public AudioClip sfxClip;
    // Start is called before the first frame update
    void Start()
    {
        var soundManager = FindObjectOfType<SoundManager>();
        sfxPlayer = soundManager.sfxPlayer[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shop()
    {
        sfxPlayer.clip = sfxClip;
        sfxPlayer.Play();
    }
}
