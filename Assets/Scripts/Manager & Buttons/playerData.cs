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
    public Vector3 playerRotation;
    public Transform playerTransform;
    public bool extraLife;
    public int nivel;

    public int flor;
    public int hierbas;
    public int mushrooms;
    //public Transform[] plantsPosition;
    //Reset posicion Bunny

    private void Start()
    {
        s_saveSystem = GetComponent<SaveSystem>();
        StartCoroutine(GuardarDatosAutomatico());
    }
    public playerData(Vector3 playerPosition, Vector3 playerRotation, bool extraLife, int nivel)
    {
        playerTransform.position = playerPosition;
        playerTransform.eulerAngles = playerRotation;
        this.extraLife = extraLife;
        this.nivel = nivel;
    }

    private void Update()
    {
        StartCoroutine(GuardarDatosAutomatico());        
    }

    IEnumerator GuardarDatosAutomatico()
    {
        yield return new WaitForSeconds(3f);
        
        if (playerPosition != lastPlayerPosition || extraLife != lastPlayerLife || nivel != lastLevel)
        {
            Debug.Log("Datos Guardados");
            s_saveSystem.GuardarDatos(playerTransform.position, playerTransform.eulerAngles, extraLife, nivel);

            // Actualizar las últimas posiciones y rotaciones conocidas
            lastPlayerPosition = playerPosition;
            lastPlayerLife = extraLife;
            lastLevel = nivel;            
        }
    }
}
