using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    //public Transform door;
    //public int transformY;
    //private int lowPosY = -4;


    //public bool doorOpened = false; //Debo saber si esta dentro para desactivar el bool y que pueda salir
                                //Y activar cuando no este dentro, para que cierre cuando entre
   

    private void Update()
    {
       // transformY = Mathf.RoundToInt(door.position.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Inventory inventory = other.GetComponent<Inventory>();

            if (inventory.flor >= 3 && inventory.mush >= 3 && inventory.hierba >= 3)
                //StartCoroutine(Open());
                print("Video Final");

            else
                print("No tienes suficientes objetos, ve a buscar mas // *Sonido de error* Tr");
            
        }
    }

    //IEnumerator Open()
    //{
    //    while (transformY != lowPosY && doorOpened == false)
    //    {
    //        Debug.Log("Bajando Puerta");
    //        transformY--;
    //        door.position = new Vector3(door.position.x, transformY , door.position.z);           

    //        yield return new WaitForSeconds(0.3f);                      
            
    //    }
        
        
    //}
}
