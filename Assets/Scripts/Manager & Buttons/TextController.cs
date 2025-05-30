using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public int nivel;

    [SerializeField] Image imgCorreo;
    [SerializeField] public TextMeshProUGUI submensajeNuevoClick;
    [SerializeField] public TextMeshProUGUI messageText;
    [SerializeField] Image img_BoxMision;
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
        img_BoxMision.GetComponent<Image>();
        
        
        
    }
    void Start()
    {
        img_BoxMision.enabled = true;
        submensajeNuevoClick.enabled = true;
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
        
        if (Input.GetMouseButtonDown(0) || Input.GetKeyUp(KeyCode.Return)) // Detecta el clic izquierdo del rat�n y boton de Enter 
        {
            if(nivel == 0)
            {
                           
                TheStartMessage();

            }

            if (nivel == 1)
            {
                
                MisionMensajes();
            }

            if (nivel == 2)
            {
                
                MisionCumplidaMensajes();
            }

           


        }
    }


            
    

    void TheStartMessage()
    {
        
        if (currentMessageIndex < MensajesIniciales.Length - 1 && nivel == 0)
        {
            currentMessageIndex++;
            messageText.text = MensajesIniciales[currentMessageIndex];
            imgCorreo.enabled = false;
            
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
            
            t_inventario.enabled= true;
            imgInventario.enabled = true;
            
            

            

            currentMessageIndex++;

            messageText.text = MensajesMisionRecolectar[currentMessageIndex];

            if(currentMessageIndex == MensajesMisionRecolectar.Length - 1)
            {
                img_BoxMision.enabled = false;
                submensajeNuevoClick.enabled = false;

            }
            imgCorreo.enabled=false;
            
            //img_tMision.color = new Color(img_tMision.color.r, img_tMision.color.g, img_tMision.color.b, 0f);
        }
        else
        {
            print("Poner el mensaje en texto mision");
        }
    }

    public void MisionCumplidaMensajes()
    {

        img_BoxMision.enabled = true;
        imgCorreo.enabled = true;
        submensajeNuevoClick.enabled = true;
        
        if (currentMessageIndex < MensajesFinMision.Length - 1 && nivel == 2)
        {
            img_BoxMision.enabled = true;
            //img_BoxMision.color = new Color(img_BoxMision.color.r, img_BoxMision.color.g, img_BoxMision.color.b, 1f);
            submensajeNuevoClick.enabled = true;
            print("Mensajes fINALES");
            currentMessageIndex++;
            messageText.text = MensajesFinMision[currentMessageIndex];
        }


        else //Para salir del bucle anterior despues de haber puesto todos los mensajes
        {
           
            print("Pon un mensaje");
            submensajeNuevoClick.enabled = false;
            nivel = 3;

        }
   
    }
}


