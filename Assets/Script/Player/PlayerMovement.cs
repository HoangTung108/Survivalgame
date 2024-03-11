using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Orientation;
    public Rigidbody rb;
    public float PlayerHeight;
    private bool isTouchingGround;
    public LayerMask GroundLayer;
    private float Horizontal;
    private float Vertical;
    private Vector3 MoveDirection;
    public float Speed;
    private bool readyToJump = true;
    public float JumpForce;
    public float JumpCoolDown;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        isTouchingGround = Physics.Raycast(transform.position,Vector3.down,PlayerHeight*0.5f+0.3f,GroundLayer);
        FallingToVoid();
        Sprint();
        Move();
        SpeedCtrl();
        Jump();
        
    }

    private void Move()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        MoveDirection = Orientation.forward*Vertical + Orientation.right*Horizontal;

        transform.Translate(MoveDirection.normalized*Speed*Time.deltaTime);
    }

    private void SpeedCtrl()
    {
        Vector3 CurrentVelocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);

        if(CurrentVelocity.magnitude > Speed)
        {
            Vector3 LimitedVelocity = CurrentVelocity.normalized*Speed*Time.deltaTime;
            rb.velocity = new Vector3(LimitedVelocity.x,rb.velocity.y,LimitedVelocity.z);
        }
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTouchingGround && readyToJump)
        {
            rb.AddForce(JumpForce*Vector3.up,ForceMode.Impulse);
            audioManager.PlaySFX(audioManager.Jump);
            readyToJump = false;
            Invoke("ResetJump", JumpCoolDown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 10f;
        }
        else
        {
            Speed = 6f;
        }
    }

    private void FallingToVoid()
    {
        if(transform.position.y <= -10f)
        {
            transform.position = new Vector3(0f,12f,0f);
        }
    }
}
