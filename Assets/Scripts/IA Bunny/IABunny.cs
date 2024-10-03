using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IABunny : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations;
    public float distanceToFollowPlayer = 5;
    public float distanceToFollowPath = 2; 

    [Header("-----------FollowPlayer?--------")]
    public bool followPlayer;

    private int i = 0;
    private GameObject player;
    [SerializeField] private float distanceToPlayer;
    
    


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
                print("Destino: " + destinations[i]);

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
        if(collision.gameObject.tag == "Player" && player.GetComponent<playerData>().extraLife == false)
        {
            playerData data = player.GetComponent<playerData>();

            QuitarObjeto(ref data.mushrooms, "Mushrooms", 3);
            QuitarObjeto(ref data.flor, "Flores", 3);
            QuitarObjeto(ref data.hierbas, "Hierbas", 3);

            ResetPosition();

        }
        if (collision.gameObject.tag == "Player" && player.GetComponent<playerData>().extraLife == true)
        {
            player.GetComponent<playerData>().extraLife = false;
            print("Eliminar imagen del champi(vida extra)");
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
