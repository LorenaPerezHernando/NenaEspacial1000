using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIChampi : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    [SerializeField] Renderer render;
    private GameObject player;
    [SerializeField] private GameObject extraVida;

    public Transform[] destinations;
    private int i;

    public int alturaDelSalto;
    public int duracionsalto = 3;

    private void Awake()
    {
        render = GetComponentInChildren<Renderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerMov>().gameObject;
    }
    void Start()
    {
        navMeshAgent.destination = destinations[i].transform.position;

        extraVida.SetActive (false);
        if (destinations.Length > 0)
        {
            StartCoroutine(MoverYSalta(destinations[i].position)); // Comienza con el primer destino
        }

    }
    void Update()
    {
        transform.LookAt(player.transform.position);
    }

    IEnumerator MoverYSalta(Vector3 destino)
    {
        // "Volar" al destino (teletransportarse)
        navMeshAgent.enabled = false; // Desactiva el agente temporalmente
        transform.position = destino;
        navMeshAgent.enabled = true; // Reactiva el agente

        // Inicia el salto
        yield return StartCoroutine(Saltar(destino));

        // Avanza al siguiente destino si hay más destinos disponibles
        if (i < destinations.Length - 1)
        {
            i++;
            yield return StartCoroutine(MoverYSalta(destinations[i].position)); // Mover y saltar al siguiente destino
        }
        else
        {
            i = 0;
            StartCoroutine(MoverYSalta(destinations[i].position));
        }
    }

    IEnumerator Saltar(Vector3 destino)
    {
        Vector3 saltoDestino = new Vector3(transform.position.x, alturaDelSalto, transform.position.z);
        Vector3 positionInicial = new Vector3(transform.position.x, 0 , transform.position.z);

        float timePassed = 0; 
        while(timePassed < duracionsalto)
        {
            transform.position = Vector3.Lerp(positionInicial, saltoDestino, timePassed / duracionsalto);
            timePassed += Time.deltaTime;  
            yield return null;


        } 
        timePassed = 0;
        while(timePassed < duracionsalto)
        {
            transform.position = Vector3.Lerp(saltoDestino, positionInicial, timePassed / duracionsalto);
            timePassed += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(2f);

    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == "Player")
        {
           player.GetComponent<Inventory>().extraLife = true;
            print("Activar imagen Vida Extra"); 
            extraVida.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<Inventory>().extraLife = true;
            print("Trigger Enter");
            extraVida.SetActive(true);
            render.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        render.enabled = true;
    }
}
