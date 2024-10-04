using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovChampi : MonoBehaviour
{
    public Transform[] destinations;
    private int i = 0;
    public float speed;
    public int alturaSalto;
    public int duracionsalto; 

    private Vector3 posicionInicial; 

    void Start()
    {
        posicionInicial = transform.position;
       
    }
    void Update()
    {
        Vector3 destino = destinations[i].position;
        transform.position = Vector3.Lerp(transform.position, destino, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, destino) <= 0.01f)
        {
            StartCoroutine(Saltar());
            //transform.position = Vector3.Lerp(transform.position, destino, speed * Time.deltaTime);

            if (i < destinations.Length - 1)
            {
                i++;
                print("Destino: " + destinations[i].name);
            }
            else
                i = 0; 
        }

    }
    IEnumerator Saltar()
    {
        Vector3 saltoDestino = new Vector3(transform.position.x, alturaSalto, transform.position.z);
        Vector3 positionInicial = new Vector3(transform.position.x, 0, transform.position.z);

        print("Saltar" + transform.position.y);
        float elapsedTime = 0;
        while (elapsedTime < duracionsalto)
        {
            transform.position = Vector3.Lerp(positionInicial, saltoDestino, elapsedTime / duracionsalto);
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        print("Destino llegado" + transform.position.y);

        yield return new WaitForSeconds(2f);

        //elapsedTime = 0;
        //while (elapsedTime < duracionsalto)
        //{
        //    transform.position = Vector3.Lerp(positionInicial, saltoDestino, elapsedTime / duracionsalto);
        //    elapsedTime += Time.deltaTime;
        //    yield return null;

        //}


    }

    
}
