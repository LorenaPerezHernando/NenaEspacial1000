using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
     public int flor;
     public int mush;
     public int hierba;
     public bool extraLife;



    [SerializeField] int nivel;
    bool misionCumplidaYMonstrada = false;
    TextController s_textController;

    private void Awake()
    {
        s_textController = FindAnyObjectByType<TextController>();
        misionCumplidaYMonstrada = false;
        nivel = FindAnyObjectByType<TextController>().nivel;
    }

    private void Update()
    {
        if (flor >= 3 && mush >= 3 && hierba >= 3  && misionCumplidaYMonstrada == false)
        {

            nivel = FindAnyObjectByType<TextController>().nivel = 2;
            if (nivel == 2)
            {
               s_textController.currentMessageIndex = 0; 
                s_textController.MisionCumplidaMensajes();

                misionCumplidaYMonstrada = true; 
            }
        }
    }

}
