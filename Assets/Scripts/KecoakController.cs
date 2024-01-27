using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class KecoakController : MonoBehaviour
{
    //public CharacterController controller;
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 10f; 
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

     Vector3 moveDirection = Vector3.zero;
    float rotationX = 0; 
    public bool canMove = true; 
    Rigidbody _rb;
    
    CharacterController characterController;
    UIController uI;
    void Start()
    {
        _rb=GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
 
    void Update()
    {
 
        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
        #endregion
 
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
 
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        #endregion
 
        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);
 
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion

        void OnCollisionEnter(Collision collision){
            if(collision.gameObject.name=="Mob"){
                uI.nyawaMob=uI.nyawaMob-1;
            }
            else if(collision.gameObject.name=="Baygon"){
                uI.nyawaPlayer=uI.nyawaPlayer=1;
            }
                else if(collision.gameObject.name=="Radar"){
                uI.rageTime(5);
            }


        }
    }
    // public Transform cam;

    // public float speed = 6;
    // public float gravity = -9.81f;
    // public float jumpHeight = 3;
    // Vector3 velocity;
    // bool isGrounded;

    // public Transform groundCheck;
    // public float groundDistance = 0.4f;
    // public LayerMask groundMask;

    // float turnSmoothVelocity;
    // public float turnSmoothTime = 0.1f;

    // // Update is called once per frame
    // void Update()
    // {
    //     //jump
    //     isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    //     if (isGrounded && velocity.y < 0)
    //     {
    //         velocity.y = -2f;
    //     }

    //     if (Input.GetButtonDown("Jump") && isGrounded)
    //     {
    //         velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    //     }
    //     //gravity
    //     velocity.y += gravity * Time.deltaTime;
    //     controller.Move(velocity * Time.deltaTime);
    //     //walk
    //     float horizontal = Input.GetAxisRaw("Horizontal");
    //     float vertical = Input.GetAxisRaw("Vertical");
    //     Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    //     if(direction.magnitude >= 0.1f)
    //     {
    //         float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //         float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //         transform.rotation = Quaternion.Euler(0f, angle, 0f);

    //         Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    //         controller.Move(moveDir.normalized * speed * Time.deltaTime);
    //     }
    // }
    //[Header("Kecoak Stats")]
    // public float throttleIncrement = 0.1f;
    // public float maxThrust = 200f;
    // public float responsiveness = 10f;
    // private float throttle;
    // private float roll;
    // private float pitch;
    // private float yaw;

    //public CharacterController controller;
   // public float speed = 6f;
   // Rigidbody rb;

    // private float responseModifier{
    //     get{
    //         return (rb.mass / 100f) * responsiveness;
    //     }
    // }

    // private void Awake(){
    //     rb=GetComponent<Rigidbody>();
    // }

    // private void HandleInput(){
    //     roll = Input.GetAxis("Horizontal");
    //     pitch = Input.GetAxis("Vertical");
    //     yaw = Input.GetAxis("Yaw");

    //     if(Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
    //     else if(Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
    //     throttle = Mathf.Clamp(throttle, 0f, 100f);
    // }

    // private void Update(){
    //    float horizontal=Input.GetAxisRaw("Horizontal");
    //    float vertical=Input.GetAxisRaw("Vertical");
    //    Vector3 direction=new Vector3(horizontal,0f,vertical).normalized;

    //    if(direction.magnitude>=0.1f){
    //     controller.Move(direction*speed*Time.deltaTime);
    //    }
       // HandleInput();
    //}

    // private void FixedUpdate(){
    //     rb.AddForce(transform.forward * maxThrust * throttle);
    //     rb.AddTorque(transform.up *yaw * responseModifier);
    //     rb.AddTorque(transform.forward *roll * responseModifier);
    //     rb.AddTorque(-transform.right *pitch * responseModifier);
    // }
}
