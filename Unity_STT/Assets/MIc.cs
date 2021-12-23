using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class MIc : MonoBehaviour
{
    AudioSource _audioSource;
    
    public bool _useMicrophone;
    public string _selectedDevice;

    public AudioMixerGroup _mixerGroupMicrophone, _mixerGroupMaster;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _mixerGroupMaster = GetComponent<AudioMixerGroup>();

    }

    public void PlayVoice()
    {
        _audioSource.Play();
        Debug.Log("재생중");
    }
    public void RecVoice()
    {
        _useMicrophone = true;
        if (_useMicrophone)
        {
            if (Microphone.devices.Length > 0)
            {
                _selectedDevice = Microphone.devices[0].ToString();
                _audioSource.outputAudioMixerGroup = _mixerGroupMicrophone;
                _audioSource.clip = Microphone.Start(_selectedDevice, true, 10, AudioSettings.outputSampleRate);
                Debug.Log("녹음중");
            }
        }
        else
        {
            _useMicrophone = false;
        }
    }

    public void SaveVoice()
    {
        SavWav.Save("Voice1", _audioSource.clip);
        Debug.Log("저장중");
    }
}
