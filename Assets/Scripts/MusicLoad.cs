using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoad : MonoBehaviour
{
    private static MusicLoad instance;
    [SerializeField] private AudioSource _music, _fx;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void PlayFX()
    {
        _fx.Play();
    }
}
