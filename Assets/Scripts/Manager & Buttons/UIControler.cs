using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class UIControler : MonoBehaviour
{

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void Play () 

    {
        SceneManager.LoadScene(1);

        
    }
    public void exit() 
    {
     Application.Quit();
    } 
}
