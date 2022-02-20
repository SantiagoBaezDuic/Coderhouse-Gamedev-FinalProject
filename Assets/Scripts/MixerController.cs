using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;

    float value;

    public void SetVolume(float sliderValue)
    {
        mixer.SetFloat("MainVolume", Mathf.Log10(sliderValue) * 20);
    }

    private void Awake()
    {
        Slider slider = GetComponentInParent<Slider>();

        slider.value = 1;
    }
}
