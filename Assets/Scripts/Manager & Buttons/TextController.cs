using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public int nivel;

    [SerializeField] Image mensajeNuevoImage;
    [SerializeField] public TextMeshProUGUI messageText;
    [SerializeField] Image img_tMision;
    [SerializeField] TextMeshProUGUI t_inventario;
    [SerializeField] Image imgInventario;
    Inventory s_Inventory;
    public string[] MensajesIniciales; 
    public string[] MensajesMisionRecolectar;
    public string[] MensajesFinMision; 
    public int currentMessageIndex = 0;

    private void Awake()
    {
        s_Inventory = FindAnyObjectByType<Inventory>();
        img_tMision.GetComponent<Image>();
        
        
        
    }
    void Start()
    {
        imgInventario.enabled = false;
        t_inventario.enabled = false;
        if (MensajesIniciales.Length > 0)
        {
            messageText.text = MensajesIniciales[currentMessageIndex]; // Mostrar el primer mensaje
            
        }
        else
        {
            Debug.LogError("No hay mensajes asignados.");
        }
    }

    void Update()
    {
        
        t_inventario.text = "Flores: " + s_Inventory.flor + " Champis: " + s_Inventory.mush + " Hierbas: " + s_Inventory.hierba;
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Return)) // Detecta el clic izquierdo del ratón y boton de Enter 
        {
            if(nivel == 0)
            {
                img_tMision.enabled = true;                
                TheStartMessage();

            }

            if (nivel == 1)
            {
                img_tMision.enabled = true;
                MisionMensajes();
            }

            if (nivel == 2)
            {
                img_tMision.enabled = true;
                MisionCumplidaMensajes();
            }

            mensajeNuevoImage.enabled = false;


        }
    }


            
    

    void TheStartMessage()
    {
        img_tMision.enabled = true;
        mensajeNuevoImage.enabled = true;
        if (currentMessageIndex < MensajesIniciales.Length - 1 && nivel == 0)
        {
            currentMessageIndex++;
            messageText.text = MensajesIniciales[currentMessageIndex];
            mensajeNuevoImage.enabled = false;
        }

        else
        {
            //t_inventario.enabled = true;
            currentMessageIndex = 0;
            nivel = 1;   

        }
    }

    void MisionMensajes()
    {

        if (currentMessageIndex < MensajesMisionRecolectar.Length - 1 && nivel ==  1)
        {
            mensajeNuevoImage.enabled = true;
            t_inventario.enabled= true;
            imgInventario.enabled = true;
            img_tMision.color = new Color(img_tMision.color.r, img_tMision.color.g, img_tMision.color.b, 0.5f);
            

            

            currentMessageIndex++;

            messageText.text = MensajesMisionRecolectar[currentMessageIndex];
            img_tMision.enabled = false;
            mensajeNuevoImage.enabled=false;
        }
        else
        {
            print("Poner el mensaje en texto mision");
        }
    }

    public void MisionCumplidaMensajes()
    {

        img_tMision.enabled = true;
        mensajeNuevoImage.enabled = true;
        if (currentMessageIndex < MensajesFinMision.Length - 1 && nivel == 2)
        {
            print("Mensajes fINALES");
            currentMessageIndex++;
            messageText.text = MensajesFinMision[currentMessageIndex];
        }


        else //Para salir del bucle anterior despues de haber puesto todos los mensajes
        {
           
            print("Pon un mensaje");
            nivel = 3;

        }
   
    }
}


