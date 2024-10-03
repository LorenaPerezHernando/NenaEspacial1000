using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;


public class OnCollisionDestroy : MonoBehaviour
{
    private GameObject player; 
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player") 
        {
            if(gameObject.tag == "Flor")
                player.GetComponent<playerData>().flor++;

            if (gameObject.tag == "Mush")
                player.GetComponent<playerData>().mushrooms++;

            if (gameObject.tag == "Hierba")
                player.GetComponent<playerData>().hierbas++;

            Destroy(gameObject, 1); 

        }
    }

    
}
