using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioItemClass {
    public string key;
    public AudioClip audio;
}

public class SoundManager : MonoBehaviour
{
    //DEFINICI�N DE SINGLETON
    private static SoundManager _instance;
    public static SoundManager instance
    {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<SoundManager>();
            }
            return _instance;
        }
    }

    //PROPIEDADES
    public AudioSource bgmAudioSource;
    public AudioSource sfxAudioSource;
    [Header("Lista de musica de fondo")]
    public List<AudioItemClass> bgmAudioItems;
    [Header("Lista de efectos de sonido")]
    public List<AudioItemClass> sfxAudioItems;


    //M�TODO PARA DARLE PLAY A UN AUDIO
    public void PlayBGMAudioClip(string _key) {
        AudioClip searchedAudio = SearchBGMAudioClip(_key);
        if (searchedAudio != null)
        {
            bgmAudioSource.clip = searchedAudio;
            bgmAudioSource.Play();
        }
        else {
            Debug.LogWarning("Audio Clip no encontrado!");
        }
        
    }

    public void PlaySFXAudioClip(string _key)
    {
        AudioClip searchedAudio = SearchSFXAudioClip(_key);
        if (searchedAudio != null)
        {
            sfxAudioSource.clip = searchedAudio;
            sfxAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio Clip no encontrado!");
        }

    }

    //M�TODO PARA MODIFICAR EL VOLUMEN
    public void SetBGMVolume(float _value) {
        if (_value <= 0)
            _value = 0;

        if (_value >= 1)
            _value = 1;

        bgmAudioSource.volume = _value;
    }

    public void SetSFXVolume(float _value)
    {
        if (_value <= 0)
            _value = 0;

        if (_value >= 1)
            _value = 1;

        sfxAudioSource.volume = _value;
    }

    //M�TODO PARA DETENER LA M�SICA
    public void StopBGMAudio() {
        if (bgmAudioSource.isPlaying)
            bgmAudioSource.Stop();
    }

    public void StopSFXAudio()
    {
        if (sfxAudioSource.isPlaying)
            sfxAudioSource.Stop();
    }

    //M�TEDO DE B�SQUEDA DE AUDIOCLIPS
    private AudioClip SearchBGMAudioClip(string _key) {
        foreach (AudioItemClass audioItem in bgmAudioItems) {
            if (audioItem.key == _key)
                return audioItem.audio;
        }

        return null;
    }

    private AudioClip SearchSFXAudioClip(string _key)
    {
        foreach (AudioItemClass audioItem in sfxAudioItems)
        {
            if (audioItem.key == _key)
                return audioItem.audio;
        }

        return null;
    }

}