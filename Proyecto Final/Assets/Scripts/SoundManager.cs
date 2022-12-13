using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip [] audios;
    [SerializeField] Slider Volume;


    private AudioSource controlAudio;

    private void Awake() 
    {
        controlAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
            Load();
    }

    public void SeleccionAudio(int indice, float volumen) {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
    public void ChangeVolume()
    {
        AudioListener.volume = Volume.value;
        Save();
    }

    private void Load()
    {
        Volume.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", Volume.value);
    }
}
