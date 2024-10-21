using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData
{
    public SaveSystem s_saveSystem;
    //public GameObject panelConfig;

    //private Vector3 lastPlayerPosition;
    //private bool lastPlayerLife;
    //private int lastLevel;

    public Vector3 playerPosition;

    public GameObject player;
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
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
        //StartCoroutine(GuardarDatosAutomatico());

    }
    public playerData(Vector3 playerPosition, bool extraLife, int nivel)
    {
        this.playerPosition = playerPosition;
        //playerTransform.eulerAngles = playerRotation;
        this.extraLife = extraLife;
        this.nivel = nivel;
    }

    //public void abrirPanelconfig()
    //{
    //    if (panelConfig.activeSelf)        
    //        panelConfig.SetActive(false);
        
    //    else 
    //    panelConfig.SetActive(true);
    //}
    //public void guardarButton()
    //{
    //    StartCoroutine(GuardarDatosAutomatico());
        
    //}

    //public IEnumerator GuardarDatosAutomatico()
    //{
    //    Debug.Log("Intento de guardado");
    //    print("PlayerPos: " + playerPosition + "LastPos: " + lastPlayerPosition);
    //    playerPosition = transform.position;
    //    if (playerPosition != lastPlayerPosition || extraLife != lastPlayerLife || nivel != lastLevel)
    //    {
    //        Debug.Log("Datos Guardados");
    //        s_saveSystem.GuardarDatos(playerPosition, extraLife, nivel);

    //        // Actualizar las últimas posiciones y rotaciones conocidas
    //        lastPlayerPosition = playerPosition;
    //        lastPlayerLife = extraLife;
    //        lastLevel = nivel;            
    //    }
    //    //!!!! IMPRIMIR VALOR VARIABLES
    //    yield return null;
    //}

    //public void CargarDatos()
    //{
    //    s_saveSystem.CargarDatos();
    //}

    
}
