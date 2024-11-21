using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class IABunny : MonoBehaviour
{
    [SerializeField] Animator bunnyAnimator;
    [SerializeField] TextMeshProUGUI t_mision;
     public NavMeshAgent navMeshAgent;
    [SerializeField] GameObject ImageextraVida; 
    //public Transform[] destinations;
    public Transform[] destinations1;
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
        navMeshAgent.destination = destinations1[i].transform.position;
        player = FindAnyObjectByType<PlayerMov>().gameObject;
        
    }
    
    private void Update()
    {

        //StartCoroutine(JumpAnim());
        
        distanceToPlayer = Vector3.Distance(transform.position,player.transform.position);
        if(distanceToPlayer < distanceToFollowPlayer  || followPlayer)
        {
            transform.LookAt(player.transform.position);

            FollowPlayer();
        }
        if(distanceToPlayer > distanceToFollowPlayer)      
        {
            transform.LookAt(destinations1[i]);

            EnemyPath();
        }
    }

    
    //IEnumerator JumpAnim()
    //{
    //    // Detener el NavMeshAgent durante el salto
    //    navMeshAgent.isStopped = true;

    //    // Activar la animación de salto
    //    bunnyAnimator.SetTrigger("Jump");

    //    // Sincronizar la posición del modelo con la animación (si es necesario)
    //    float animationLength = bunnyAnimator.GetCurrentAnimatorStateInfo(0).length;
    //    float elapsedTime = 0; 

    //    Vector3 startPosition = transform.position;

    //    while(elapsedTime < animationLength)
    //    {
    //        transform.position = bunnyAnimator.transform.position;
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //        elapsedTime = 0;
    //    }

    //    // Simula un pequeño retraso mientras se ejecuta la animación
    //    //yield return new WaitForSeconds(animationLength);

    //    // Reactivar el NavMeshAgent
    //    navMeshAgent.isStopped = false;
    //}
    public void EnemyPath()
    {

        navMeshAgent.destination = destinations1[i].position;
        
        if(Vector3.Distance(transform.position, destinations1[i].position ) <= distanceToFollowPath)
        {
            if (destinations1[i] != destinations1[destinations1.Length - 1] )            
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
        //t_mision.text = "Cuidado con el e-bunny";
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
            ImageextraVida.SetActive(false);
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
        transform.position = destinations1[destinations1.Length - 1].position;
    }
}
