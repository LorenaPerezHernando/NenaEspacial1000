using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidades")]
    [SerializeField] float baseSpeed = 5f;
    [SerializeField] float dashSpeed = 8f;
    [SerializeField] float rotationSpeed = 120f;

    [Header("Componentes")]
    public Animator anim;
    private Rigidbody rb;

    [Header("Salto")]
    public bool isGrounded = true;

    [Header("Audio")]
    public MusicManager musicManager;


    private float moveInput;
    private float turnInput;
    private float currentSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical");   
        turnInput = Input.GetAxis("Horizontal");

        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? dashSpeed : baseSpeed;


        bool isWalking = Mathf.Abs(moveInput) > 0.1f;
        anim.SetBool("Walk", isWalking);
        anim.SetBool("Run", Input.GetKey(KeyCode.LeftShift) && isWalking);


        if (isWalking)
            musicManager.MusicPlay(1);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            anim.SetTrigger("Jump");
            anim.SetBool("Walk", false);
            anim.SetBool("Run", false);
            JumpAction();
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, turnInput * rotationSpeed * Time.fixedDeltaTime);

        Vector3 moveDirection = transform.forward * moveInput;
        Vector3 newPosition = rb.position + moveDirection * currentSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
    void JumpAction()
    {
        rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        isGrounded = false; 
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }
}
