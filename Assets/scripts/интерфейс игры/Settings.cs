using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)//это необходимо для работы ползунка
    {
        //можно было использовать вместо этого значения число, но программа тогда бы работала некорректно, из-за этого используется формула
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetQuality(int qualityIndex)//для установки качества
    {
        QualitySettings.SetQualityLevel(qualityIndex);//устанавивается соответсвующее качество по индексу
    }

    public void Sound()//для вкл/выкл звука 
    {
        AudioListener.pause = !AudioListener.pause;//если true то все звуки будут на паузе
    }


}
