using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    private Inventario s_Inventario;
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    IEnumerator GetPlant()
    {
        yield return new WaitForSeconds(2); 
        if(gameObject.tag == "Flor")
        {
            s_Inventario.flor++;
        }
        if(gameObject.tag == "Mush")
        {
            s_Inventario.mushrooms++;
        }
        if(gameObject.tag == "Hierba")
        {
            s_Inventario.hierbas++; 
        }
    }
}
