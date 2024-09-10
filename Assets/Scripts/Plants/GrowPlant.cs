using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrowPlant : MonoBehaviour
{
    public GameObject prefabPlant;
    public int moveY;
    public int highPosY;
    [SerializeField] int PosActualY;
    void Start()
    {
        //Coger la posicion Y del gameObject e igalarlo a un int
        PosActualY = Mathf.RoundToInt(transform.position.y);
        StartCoroutine(CreatePlant());
    }

    
    void Update()
    {
        
    }
    
    IEnumerator CreatePlant()
    {
        GameObject instancePlant = Instantiate(prefabPlant, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        instancePlant.transform.SetParent(this.transform);
        yield return null;
        StartCoroutine(Grow());
    }

    IEnumerator Grow()
    {
        while (highPosY != PosActualY)
        {
            PosActualY++;
            transform.position = new Vector3(transform.position.x, PosActualY, transform.position.z);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
