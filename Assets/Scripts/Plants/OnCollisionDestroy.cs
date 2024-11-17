using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;


public class OnCollisionDestroy : MonoBehaviour
{
    private GameObject player;
    public int tiempoDeEsperaParaActivarObjeto = 4;
    [SerializeField] Collider thisCollider;
    [SerializeField] Renderer thisRenderer;
    

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
        thisRenderer = GetComponentInChildren<Renderer>();
        thisCollider = GetComponent<Collider>();
        //thisRenderer = GetComponent<Renderer>();    
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Flor")
                player.GetComponent<Inventory>().flor++;


            if (gameObject.tag == "Mush")
                player.GetComponent<Inventory>().mush++;


            if (gameObject.tag == "Hierba")
                player.GetComponent<Inventory>().hierba++;

            DesactivarObjeto();

          
        }
    }

    IEnumerator ActivarObjeto()
    {
        print("Activar Objeto");
        yield return new WaitForSeconds(tiempoDeEsperaParaActivarObjeto);
        thisCollider.enabled = true;
        thisRenderer.enabled = true;
        
    }
    private void DesactivarObjeto()
    {
        thisCollider.enabled = false;
        thisRenderer.enabled = false;

       StartCoroutine(ActivarObjeto());
    }




}
