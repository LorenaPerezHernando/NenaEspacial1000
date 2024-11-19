using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// DESCRIPCION: Gestor del hilo musical
/// 
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager THIS;

    public AudioSource audioSource;

    public AudioClip[] musics; //Lista de musica y en cada script poner el donde quieres poner la musica
                               // MusicManager.THIS.MusicPlay(5); //El numero de la lista 

    private void Awake()
    {
        audioSource.volume = 0.40f;
        THIS = this;
        audioSource = GetComponent<AudioSource>();

        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    public void MusicPlay( int _index)
    {
        audioSource.clip = musics[_index];
        //audioSource.loop = _isLooping;

        audioSource.Play();
    }

    public void MusicStop()
    {
        if (audioSource.isPlaying) audioSource.Stop();
    }

    public void MusicPause()
    {
        if (audioSource.isPlaying) audioSource.Pause();
    }
    
    public IEnumerator FadeOut(float FadeTime)
    {
        if (audioSource.isPlaying)
        {
            
            float startVolume = audioSource.volume;

            while (audioSource.volume > 0)
            {
                audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
           
        }

    }
}
