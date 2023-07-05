using UnityEngine;
using UnityEngine.Audio;


public class MasterVolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetVolume(float SliderVolume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(SliderVolume) * 20);
    }
}
