using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float currentSpeed;
    public float walkingSpeed = 7f;
    public float runningSpeed = 14f;

    public float gravity = -0.5f;

    public float jumpSpeed = 0.8f;
    private float baseLineGravity;
    private Rigidbody rb;
    
    public CharacterController characterController;
    private float moveX;
    private float moveZ;
    private Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;
        baseLineGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
      //   Debug.Log(characterController.isGrounded);

        moveX = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        moveZ = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right*moveX+
            transform.up*gravity+
            transform.forward*moveZ;
        characterController.Move(move);

        if (Input.GetKey(KeyCode.LeftShift)) {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = walkingSpeed;
        }

        
        
        
        if (characterController.isGrounded == true && Input.GetButtonDown("Jump"))
        {
            gravity = baseLineGravity;
            gravity *= -jumpSpeed;

        }
        if (gravity > baseLineGravity)
        {
            gravity -= 2 * Time.deltaTime;
        }



}
}
