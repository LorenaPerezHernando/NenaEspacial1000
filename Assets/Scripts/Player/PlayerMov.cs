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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
        //anim.SetBool("Walk", true);


        if(rb.velocity.x > 0.01f || rb.velocity.z > 0.01f)
        {
            anim.SetBool("Walk", true);

        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speed + dash;
            anim.SetBool("Run", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed - dash;
            anim.SetBool("Run", false) ;

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            JumpAction();

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


}
