using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class OnCollisionDestroy : MonoBehaviour
{
    [SerializeField] MusicManager musicManager;
    private GameObject player;
    [SerializeField] Animator playerAnim;
    public int tiempoDeEsperaParaActivarObjeto = 10;
    [SerializeField] GameObject children;
    [SerializeField] Collider thisCollider;
    [SerializeField] Renderer thisRenderer;
    

    private void Awake()
    {
        musicManager = GameObject.FindGameObjectWithTag("SoundController").GetComponent<MusicManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponentInChildren<Animator>();
        thisRenderer = GetComponentInChildren<Renderer>();
        thisCollider = GetComponent<Collider>();
        //thisRenderer = GetComponent<Renderer>();    
    }

    private void Start()
    {
        GetChild();
    }

    void GetChild()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("Children"))
            {
                children = child.gameObject;
                break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(AnimGetRecolectable());

            if (gameObject.tag == "Flor")
                player.GetComponent<Inventory>().flor++;


            if (gameObject.tag == "Mush")
                player.GetComponent<Inventory>().mush++;


            if (gameObject.tag == "Hierba")
                player.GetComponent<Inventory>().hierba++;

            DesactivarObjeto();


        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision Con Player");
            StartCoroutine(AnimGetRecolectable());

            if (gameObject.tag == "Flor")
                player.GetComponent<Inventory>().flor++;


            if (gameObject.tag == "Mush")
                player.GetComponent<Inventory>().mush++;


            if (gameObject.tag == "Hierba")
                player.GetComponent<Inventory>().hierba++;

            StartCoroutine(DesactivarObjeto());
            

          
        }
    }

    IEnumerator AnimGetRecolectable()
    {
       // Animator playerAnim = player.GetComponent<Animator>();
        playerAnim.SetTrigger("Collect");
        player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1); //Time to collect
        player.GetComponent<PlayerMovement>().enabled = true;
    }


    IEnumerator ActivarObjeto()
    {
        print("Activar Objeto");
        yield return new WaitForSeconds(20);
        children.SetActive(true);
        thisCollider.enabled = true;
        //thisRenderer.enabled = true;
        
    }

    IEnumerator  DesactivarObjeto()
    {
        musicManager.MusicPlay(0);
        yield return new WaitForSeconds(0.1f);
        children.SetActive(false);
        thisCollider.enabled = false;
        //thisRenderer.enabled = false;

       StartCoroutine(ActivarObjeto());
    }




}
