using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoInicial : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();  
    }
    void  Start()
    {
        StartCoroutine(PrepareAndPlayVideo());

    }
    IEnumerator PrepareAndPlayVideo()
    {
        string videoPath = Path.Combine(Application.streamingAssetsPath, "Cinematicaintro.mp4");

        if (File.Exists(videoPath))
        {
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = videoPath;
            videoPlayer.Prepare();  // Comienza a preparar el video

            Debug.Log(" Preparando video...");

            // Espera a que se cargue
            while (!videoPlayer.isPrepared)
            {
                yield return null; // Espera 1 frame
            }

            Debug.Log("Video preparado. Reproduciendo...");
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError(" Video no encontrado en la ruta: " + videoPath);
        }
    }


}
