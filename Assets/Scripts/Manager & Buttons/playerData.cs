using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData : MonoBehaviour
{
    public SaveSystem s_saveSystem;

    private Vector3 lastPlayerPosition;
    private bool lastPlayerLife;
    private int lastLevel;

    public Vector3 playerPosition;
    //public Transform playerPosition;
    public bool extraLife;
    public int nivel;

    public int flor;
    public int hierbas;
    public int mushrooms;
    //public Transform[] plantsPosition;
    //Reset posicion Bunny

    private void Start()
    {
        playerPosition = transform.position;
        StartCoroutine(GuardarDatosAutomatico());

    }
    public playerData(Vector3 playerPosition, bool extraLife, int nivel)
    {
        this.playerPosition = playerPosition;
        //playerTransform.eulerAngles = playerRotation;
        this.extraLife = extraLife;
        this.nivel = nivel;
    }

    private void Update()
    {
         
    }

    public void guardarButton()
    {
        StartCoroutine(GuardarDatosAutomatico());
    }

    IEnumerator GuardarDatosAutomatico()
    {
        Debug.Log("Intento de guardado");
        //!!! IMPRIMIR VALOR VARIABLES
        if (playerPosition != lastPlayerPosition || extraLife != lastPlayerLife || nivel != lastLevel)
        {
            Debug.Log("Datos Guardados");
            s_saveSystem.GuardarDatos(playerPosition, extraLife, nivel);

            // Actualizar las últimas posiciones y rotaciones conocidas
            lastPlayerPosition = playerPosition;
            lastPlayerLife = extraLife;
            lastLevel = nivel;            
        }
        //!!!! IMPRIMIR VALOR VARIABLES
        yield return null;
    }

    IEnumerator GuardadoWhile()
    {
        while (true)
        {
            StartCoroutine(GuardarDatosAutomatico());
            yield return new WaitForSeconds(1f);
        }
    }
}
