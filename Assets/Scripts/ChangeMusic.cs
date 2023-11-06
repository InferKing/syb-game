using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    private void Start()
    {
        AudioSource clip = FindObjectOfType<MusicLoad>().GetComponent<AudioSource>();
        clip.clip = _musicClip;
        clip.Play();
    }
}
