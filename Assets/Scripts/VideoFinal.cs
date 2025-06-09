using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFinal : MonoBehaviour
{
    public PlayVideoFinal s_playVideoFinal;
    public GameObject cam;
    public GameObject cameraPlayer;
    public VideoPlayer Victory;
    public GameObject canvasjuego;
    public GameObject canvasvideo;
    void Start()
    {
     //cam.SetActive(false);   
    }
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            cameraPlayer.SetActive(false);
            cam.SetActive(true);
            cam.GetComponent<Camera>().enabled = true;
            canvasjuego.SetActive(false);
            canvasvideo.SetActive(true);
            //VideoPlayer
            Victory.gameObject.SetActive(true);
            Victory.enabled = true;

            s_playVideoFinal.SetAndPlay("Mili-victory-2.mp4");
            
        }
    }


}

