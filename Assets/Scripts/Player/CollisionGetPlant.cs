using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGetPlant : MonoBehaviour
{
    [SerializeField] Inventory inventory; 
    [SerializeField] bool listoParaCosecha;

    private void OnCollisionEnter(Collision collision)
    {
        GetPlant();
    }
    void GetPlant()
    {
        if(gameObject.tag == "Flor")
        {
            inventory.flor++;
        }
        if(gameObject.tag == "Mush")
        {
            inventory.mush++;
        }
        if(gameObject.tag == "Hierba")
        {
            inventory.hierba++; 
        }
    }
}
