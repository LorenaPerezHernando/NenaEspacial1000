using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GrowPlant : MonoBehaviour
{
    public int highPosY;
    [SerializeField] Vector3 transformStatic;
    [SerializeField] Vector3 positionGrown;
    [SerializeField] int PosActualY;
    [SerializeField] Vector3 plantTransform;
    public float crecimiento;
    private int i = 0;

    public bool fullyGrown;
    void Start()
    {
        //Coger la posicion Y del gameObject e igalarlo a un int
        
        
        transformStatic = new Vector3(transformStatic.x, highPosY, transformStatic.z);
        positionGrown = new Vector3(transform.position.x, PosActualY, transform.position.x);
        StartCoroutine(Grow());
    }
  

    IEnumerator Grow()
    {
        
        
            while (PosActualY != highPosY)
            {
                plantTransform = new Vector3 (transform.position.x, transform.position.y + crecimiento, transform.position.z);               
                
                i++; 
            }

        yield return new WaitForSeconds(1f);
        
         if (highPosY == PosActualY)
                fullyGrown = true;
            

        
    }
}
