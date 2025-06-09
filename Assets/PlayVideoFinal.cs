using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideoFinal : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    private string _videoFileName = "Mili-victory-2.mp4";
    [SerializeField] private GameObject _blackScreen;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        
    }
    void Start()
    {
        //StartCoroutine(PrepareAndPlayVideo());

    }
    public void SetAndPlay(string videoFileName)
    {
        _videoFileName = videoFileName;
        _blackScreen?.SetActive(true); 
        StartCoroutine(PrepareAndPlayVideo());
    }

    IEnumerator PrepareAndPlayVideo()
    {
        string videoPath = Path.Combine(Application.streamingAssetsPath, _videoFileName);

        if (Application.platform == RuntimePlatform.WebGLPlayer || File.Exists(videoPath))

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
            _blackScreen?.SetActive(false);
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError(" Video no encontrado en la ruta: " + videoPath);
        }
    }
}

