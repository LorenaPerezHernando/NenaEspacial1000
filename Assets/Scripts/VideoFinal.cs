using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFinal : MonoBehaviour
{
    public GameObject camera;
    public GameObject cameraPlayer;
    public VideoPlayer Victory;
    public GameObject canvasjuego;
    public GameObject canvasvideo;
    // Start is called before the first frame update
    void Start()
    {
     //camera.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            cameraPlayer.SetActive(false);
            camera.SetActive(true);
            camera.GetComponent<Camera>().enabled = true;
            canvasjuego.SetActive(false);
            canvasvideo.SetActive(true);
            //VideoPlayer
            Victory.gameObject.SetActive(true);
            Victory.enabled = true; 
            Victory.Prepare();
            Victory.Play();
        }
    }


}

