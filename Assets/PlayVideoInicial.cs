using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoInicial : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();  
    }
    void Start()
    {
        // Ruta del video en StreamingAssets
        string videoPath = Path.Combine(Application.streamingAssetsPath, "Cinematicaintro.mp4");

        // Asegurarse de que el archivo exista
        if (File.Exists(videoPath))
        {
            // Asignar el video al VideoPlayer
            videoPlayer.url = videoPath;

            // Reproducir el video
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("Video no encontrado en la ruta: " + videoPath);
        }
    }

}
