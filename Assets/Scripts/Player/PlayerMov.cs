using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour
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

        #region Inputs PC
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        //Saber si se ha movido de posicion y utilizalo en el if
        Vector3 previousPos = rb.position;
        Vector3 newPosition = (rb.position + move * speed * Time.deltaTime);
        rb.MovePosition(newPosition);
        #endregion

        bool isMoving = Vector3.Distance(previousPos, newPosition) > 0.01f;
        previousPos = rb.position;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump"); anim.SetBool("Walk", false); anim.SetBool("Run", false) ;
            JumpAction();

        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) )
        {
            MusicManager.THIS.MusicPlay(1);
            anim.SetBool("Walk", true);

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("Run" , false);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow) || !isMoving)
        {
            anim.SetBool("Walk", false);

        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("Magnitude" + move.magnitude);
            MusicManager.THIS.MusicPlay(1);
            speed = dash;
            anim.SetBool("Walk", false );
            anim.SetBool("Run", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            dash = speed ;
            anim.SetBool("Run", false) ;

        }

        
        

        if(Input.GetKeyDown(KeyCode.Escape)) 
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
        if(collision.gameObject.tag == "Terrain")
            isGrounded=true;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
            isGrounded=true;
    }


}
