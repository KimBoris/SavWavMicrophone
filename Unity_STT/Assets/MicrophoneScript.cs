using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MicrophoneScript : MonoBehaviour
{
    AudioSource audio;

    public bool useMicrophone;
    public string selectedDevice;


    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void SaveVoice()
    {
        SavWav.Save("Voice1", audio.clip);
    }

    public void InputVoice()
    {
        if (Microphone.devices.Length > 0)
        {
            useMicrophone = true;
            if (useMicrophone)
            {
                selectedDevice = Microphone.devices[0].ToString();//����̽� ����
                Microphone.Start(selectedDevice, true, 5, AudioSettings.outputSampleRate); //����ũ �Է� ����

                Invoke("SaveVoice", 3);
            }
        }
        else
        {
            useMicrophone = false;
        }
    }
    public void PlayVoice()
    {
        audio.Play();
    }
}
