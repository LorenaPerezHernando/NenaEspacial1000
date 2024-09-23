using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGetPlant : MonoBehaviour
{
    private playerData s_playerData;
    [SerializeField] bool listoParaCosecha;

    private void OnCollisionEnter(Collision collision)
    {
        GetPlant();
    }
    void GetPlant()
    {
        if(gameObject.tag == "Flor")
        {
            s_playerData.flor++;
        }
        if(gameObject.tag == "Mush")
        {
            s_playerData.mushrooms++;
        }
        if(gameObject.tag == "Hierba")
        {
            s_playerData.hierbas++; 
        }
    }
}
