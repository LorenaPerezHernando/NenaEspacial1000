using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class IABunny : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t_mision;
    public NavMeshAgent navMeshAgent;
    [SerializeField] GameObject extraVida; 
    public Transform[] destinations;
    public float distanceToFollowPlayer = 5;
    public float distanceToFollowPath = 2; 

    [Header("-----------FollowPlayer?--------")]
    public bool followPlayer;

    private int i = 0;
    private GameObject player;
    [SerializeField] private float distanceToPlayer;


    private void Awake()
    {
        t_mision = FindAnyObjectByType<TextController>().messageText;
    }



    void Start()
    {
        navMeshAgent.destination = destinations[i].transform.position;
        player = FindAnyObjectByType<PlayerMov>().gameObject;
    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position,player.transform.position);
        if(distanceToPlayer < distanceToFollowPlayer  || followPlayer)
        {
            FollowPlayer();
        }
        if(distanceToPlayer > distanceToFollowPlayer)      
        {
            EnemyPath();
        }
    }
    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;
        
        if(Vector3.Distance(transform.position, destinations[i].position ) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1] )            
            {
                i++;                
                if(distanceToPlayer < distanceToFollowPlayer || followPlayer)
                {
                    FollowPlayer();
                }
            }
            else
            {
                i = 0; 

            }
        }
        
    }
    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && player.GetComponent<Inventory>().extraLife == false)
        {
            Inventory data = player.GetComponent<Inventory>();

            if (player.GetComponent<Inventory>().mush >= 3 && player.GetComponent<Inventory>().flor >= 3 && player.GetComponent<Inventory>().hierba >= 3)
                print("No robar los objetos, tiene 3 de cada");

            else
            {
                t_mision.text = "El eBunny te ha quitado plantas, ten cuidado";

                QuitarObjeto(ref data.mush, "Mushrooms", 3);
                QuitarObjeto(ref data.flor, "Flores", 3);
                QuitarObjeto(ref data.hierba, "Hierbas", 3);

                ResetPosition();

            }

        }
        if (collision.gameObject.tag == "Player" && player.GetComponent<Inventory>().extraLife == true)
        {
            player.GetComponent<Inventory>().extraLife = false;
            print("Eliminar imagen del champi(vida extra)");
            extraVida.SetActive(false);
            ResetPosition();

        }
    }

    private void QuitarObjeto(ref int objeto, string nombreObjeto, int cantidad)
    {
        if (objeto >= cantidad)
        {
            objeto -= cantidad;
            print($"Se han quitado {cantidad} {nombreObjeto}.");
        }
        else if (objeto == 0)
        {
            print($"No le puedes quitar {nombreObjeto} al player, no tiene.");
        }
        else
        {
            objeto -= 1; // O ajusta esto a la lógica que desees para los casos intermedios
            print($"No tiene suficientes {nombreObjeto}, pero se le quitó 1.");
        }
    }

    private void ResetPosition()
    {
        transform.position = destinations[destinations.Length - 1].position;
    }
}
