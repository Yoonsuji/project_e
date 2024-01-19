using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    public void PlayHeartAni()
    {
        animator.SetTrigger("HeartDelect");
        audioSource.Play();
    }
}
