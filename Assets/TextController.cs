using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private float nivel; 

    [SerializeField] private TextMeshProUGUI messageText; 
    public string[] MensajesIniciales; 
    public string[] MensajesMisionRecolectar;
    public string[] MensajesFinMision; 
    private int currentMessageIndex = 0;

    private void Awake()
    {
        nivel = GameObject.FindWithTag("Player").GetComponent<Inventory>().nivel;
    }
    void Start()
    {
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
        if (Input.GetMouseButtonDown(0)) // Detecta el clic izquierdo del ratón
        {
            if(nivel == 0) 
                NextMessage();

            if (nivel == 1)
                MisionMensajes();

            
        }
    }

    void NextMessage()
    {
        if (currentMessageIndex < MensajesIniciales.Length - 1)
        {
            currentMessageIndex++;
            messageText.text = MensajesIniciales[currentMessageIndex];
        }

        else
        {
            currentMessageIndex = 0;
            nivel = 1;               
        }
    }

    void MisionMensajes()
    {
       
            if (currentMessageIndex < MensajesMisionRecolectar.Length - 1)
            {
                currentMessageIndex++;
                messageText.text = MensajesMisionRecolectar[currentMessageIndex];
            }
            else
            {
                print("Poner el mensaje en texto mision");
            }
    }

    void MisionCumplidaMensajes()
    {
        if(nivel == 1.5)
        {
            if (currentMessageIndex < MensajesFinMision.Length - 1)
            {
                currentMessageIndex++;
                messageText.text = MensajesFinMision[currentMessageIndex];
            }
            else
            {
                print("Poner el mensaje en texto mision");
            }
        }
    }
}


