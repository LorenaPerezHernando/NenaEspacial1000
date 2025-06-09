using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoInicial : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    [SerializeField] private GameObject _blackScreen;

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

        if(Application.platform == RuntimePlatform.WebGLPlayer || File.Exists(videoPath))

            {
                videoPlayer.source = VideoSource.Url;

#if UNITY_WEBGL && !UNITY_EDITOR
            videoPlayer.url = videoPath;
#else
            videoPlayer.url = "file://" + videoPath;
#endif

            //videoPlayer.url = videoPath;
            videoPlayer.Prepare();  

            Debug.Log(" Preparando video...");

            while (!videoPlayer.isPrepared)
            {
                yield return null; 
            }

            Debug.Log("Video preparado. Reproduciendo...");
            _blackScreen.SetActive(false);
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError(" Video no encontrado en la ruta: " + videoPath);
        }
    }


}
