using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SoundData
{
    public float mainVolume, fxVolume, musicVolume;
}
public class SettingsData : MonoBehaviour
{
    [SerializeField] private Slider _mainSoundSlider, _fxSoundSlider, _musicSoundSlider;
    private SoundData _data;
    private void Start()
    {
        _data = new SoundData();
        _data.mainVolume = PlayerPrefs.GetFloat("mainVolume", 0.7f);
        _data.fxVolume = PlayerPrefs.GetFloat("fxVolume", 0.7f);
        _data.musicVolume = PlayerPrefs.GetFloat("musicVolume", 0.7f);
    }
    public void SaveData() {
        _data.mainVolume = _mainSoundSlider.value;
        _data.fxVolume = _fxSoundSlider.value;
        _data.musicVolume = _musicSoundSlider.value;
        PlayerPrefs.SetFloat("mainVolume", _data.mainVolume);
        PlayerPrefs.SetFloat("fxVolume", _data.fxVolume);
        PlayerPrefs.SetFloat("musicVolume", _data.musicVolume);
    }
}
