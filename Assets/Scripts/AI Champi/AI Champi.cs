using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AIChampi : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator anim; 
    private GameObject player;

    public Transform[] destinations;
    private int i;

    private int maxRepetitions = 4;
    public int alturaDelSalto;

    public int duracionsalto = 3;

    void Start()
    {
        anim.SetTrigger("Saltar");
        //navMeshAgent.destination = destinations[i].transform.position;
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<PlayerMov>().gameObject;


       
    }

    // Update is called once per frame
    void Update()
    {
       

        navMeshAgent.destination = destinations[i].position;
        if (Vector3.Distance(transform.position, destinations[i].position) <= 0.01f)
        {
            navMeshAgent.destination = destinations[i].position;

            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
                navMeshAgent.destination = destinations[i].position;
                print("Destino: " + destinations[i]);
                StartCoroutine(Saltar());
            }
            else
            {
                i = 0;
            }
        }
    }

    IEnumerator Saltar()
    {
        Vector3 saltoDestino = new Vector3(transform.position.x, alturaDelSalto, transform.position.z);
        Vector3 positionInicial = new Vector3(transform.position.x, 0 , transform.position.z);

        float elapsedTime = 0; 
        while(elapsedTime < duracionsalto)
        {
             transform.position= Vector3.Lerp(positionInicial, saltoDestino, elapsedTime/duracionsalto);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        //navMeshAgent.SetDestination(saltar);
        print("Destino llegado" + transform.position.y); 
  
        yield return new WaitForSeconds(2f);     

    }

    private void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == "Player")
        {
           player.GetComponent<playerData>().extraLife = true;
            print("Activar imagen Vida Extra"); 
        }
    }
}
