using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateClose : MonoBehaviour
{
    public OpenDoor s_openDoor;
    public GameObject s_closeDoor;
    private void OnTriggerExit(Collider other)
    {
        
        s_openDoor.inside = true;
        s_closeDoor.gameObject.GetComponent<CloseDoor>().enabled = true; 
    }
}
