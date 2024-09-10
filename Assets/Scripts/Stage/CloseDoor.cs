using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public Transform door;


    //[SerializeField] int transformY;
    private int highPosY = 1;

    public OpenDoor s_opendoor;


    private void Start()
    {
        
        s_opendoor = GetComponentInParent<OpenDoor>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Close());
        }
    }

   

    IEnumerator Close()
    {
        
            while (s_opendoor.transformY != highPosY && s_opendoor.inside == false)
            {
                Debug.Log("Subiendo puerta");
                s_opendoor.transformY++;
                door.position = new Vector3(door.position.x, s_opendoor.transformY, door.position.z);
                yield return new WaitForSeconds(0.3f);
                
            }
            if (s_opendoor.transformY != highPosY)
                 s_opendoor.inside = false; 
                

    }

    private void OnTriggerExit(Collider other)
    {
        s_opendoor.inside = false;
    }


}