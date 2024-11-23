using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoInicial : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        // Obtiene el componente VideoPlayer del objeto
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer == null)
        {
            Debug.LogError("No se encontró un VideoPlayer en este objeto.");
            return;
        }

        // Suscribirse al evento de finalización del video
        videoPlayer.loopPointReached += OnVideoFinished;

        // Reproducir el video al iniciar
        videoPlayer.Play();
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        // Desactiva el objeto después de que el video termina
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        // Asegurarse de desuscribirse del evento para evitar errores
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}
