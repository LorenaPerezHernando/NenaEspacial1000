using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    //public Transform door;
    //private int highPosY = 1;
    //public OpenDoor s_opendoor;

    //public IEnumerator Close()
    //{
    //    //Cerrar si el interruptor ha sido pisado (booleana doorOpened) 
    //    while (s_opendoor.transformY != highPosY && s_opendoor.doorOpened == true)
    //    {
    //       Debug.Log("Subiendo puerta");
    //        s_opendoor.transformY++;
    //        door.position = new Vector3(door.position.x, s_opendoor.transformY, door.position.z);
    //        yield return new WaitForSeconds(0.3f);

    //    }

    //    //Se da cuenta si esta cerrada, entonces cambia bool para poder abrir
    //    if (s_opendoor.transformY == highPosY)
    //    {
    //        s_opendoor.doorOpened = false;
    //        //!!!ACTIVAR Y SABER SI LO VOY A DEJAR EN EL UPDATE Debug.Log("La puerta ahora esta cerrada");
    //    }

    //    yield return null;
    //}
}