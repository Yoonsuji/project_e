using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager_STG : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayAudioAfterDelay(17f));
    }

    // Update is called once per frame
    IEnumerator PlayAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
