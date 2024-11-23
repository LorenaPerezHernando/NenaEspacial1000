using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov2 : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] Animator anim;
    public float speed = 4f;
    public float dash;
    public float jumpForce = 5f;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //Saber si se ha movido de posicion y utilizalo en el if
        Vector3 previousPos = rb.position;
        Vector3 newPosition = (rb.position + move * speed * Time.deltaTime);
        rb.MovePosition(newPosition);

        bool isMoving = Vector3.Distance(previousPos, newPosition) > 0.01f;
        previousPos = rb.position;


        bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) ||
                     Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        bool isRunning = isWalking && Input.GetKey(KeyCode.LeftShift);

        // Caminar
        if (isWalking && !isRunning)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
            MusicManager.THIS.MusicPlay(1); // Solo reproduce música al caminar
        }
        // Correr
        else if (isRunning)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", true);
            speed = speed + dash; // Aumenta la velocidad al correr
        }
        // Detener movimiento
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            speed = speed - dash ; // Resetea la velocidad al detenerse
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            JumpAction();

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }


    }

    private void JumpAction()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
            isGrounded = true;
    }
}
