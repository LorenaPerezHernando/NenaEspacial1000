using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    //¿¿?¿?¿ PONER MOUSE SENSITIVITY PARA X Y PARA Y DISTINTAS ?¿?¿?¿?
    private float mouseSensitivityX = 300f;
    private float mouseSensitivityY = 80f;
   

    public Transform playerBody; 

    float xRotation = 0f;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;

        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 40f); //CAPAR LA ROTACION 
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
