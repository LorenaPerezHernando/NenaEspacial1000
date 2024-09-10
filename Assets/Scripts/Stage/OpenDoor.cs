using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform door;
    public int transformY;
    private int lowPosY = -4;


    public bool inside = false; //Debo saber si esta dentro para desactivar el bool y que pueda salir
                                //Y activar cuando no este dentro, para que cierre cuando entre
    public GameObject s_entradaQueDesactiva;

    private void Update()
    {
        transformY = Mathf.RoundToInt(door.position.y);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        while (transformY != -4 || inside == false)
        {
            Debug.Log("Bajando Puerta");
            transformY--;
            door.position = new Vector3(door.position.x, transformY, door.position.z);
            yield return new WaitForSeconds(0.3f);

            
            
            if (transformY == lowPosY && s_entradaQueDesactiva != null)
            {
                inside = true;
                s_entradaQueDesactiva.GetComponent<CloseDoor>().enabled = false; 

            }
        }
        
    }
}
