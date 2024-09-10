using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClose : MonoBehaviour
{
    public OpenDoor s_openDoor;
    public CloseDoor s_closeDoor;



    private void Start()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        s_openDoor.doorOpened = false;
        StartCoroutine(Activar());
    }

    IEnumerator Activar()
    {
        yield return new WaitForSeconds(5);

        if(s_openDoor.doorOpened == false)
        {
            s_closeDoor.gameObject.GetComponent<CloseDoor>().enabled = true; 
            
        }

    }
}
