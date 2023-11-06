using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundData
{
    public float mainVolume, fxVolume, musicVolume;
}
public class SettingsData : MonoBehaviour
{
    [SerializeField] private Slider _mainSoundSlider, _fxSoundSlider, _musicSoundSlider;
    [SerializeField] private AudioMixer _musicMixer;
    private SoundData _data;
    private void Start()
    {
        _data = new SoundData();
        _data.mainVolume = PlayerPrefs.GetFloat("mainVolume", 1f);
        _data.fxVolume = PlayerPrefs.GetFloat("fxVolume1", 1f);
        _data.musicVolume = PlayerPrefs.GetFloat("musicVolume1", 1f);
        _mainSoundSlider.value = _data.mainVolume;
        _fxSoundSlider.value = _data.fxVolume;
        _musicSoundSlider.value = _data.musicVolume;
    }
    public void SaveData() {
        _data.mainVolume = _mainSoundSlider.value;
        _data.fxVolume = _fxSoundSlider.value;
        _data.musicVolume = _musicSoundSlider.value;
        PlayerPrefs.SetFloat("mainVolume", _data.mainVolume);
        PlayerPrefs.SetFloat("fxVolume1", _data.fxVolume);
        PlayerPrefs.SetFloat("musicVolume1", _data.musicVolume);
        _musicMixer.SetFloat("MasterVolume", (_data.mainVolume - 0.9f) * 80);
        _musicMixer.SetFloat("MusicVolume", (_data.musicVolume - 0.9f) * 80);
        _musicMixer.SetFloat("FXVolume", (_data.fxVolume - 0.9f) * 80);
    }
}
