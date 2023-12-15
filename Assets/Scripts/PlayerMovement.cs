using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

    public HealthBar healthBar;


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

    [Range(1, 10)]
    public float jumpVelocity;

    void Start()
    {
        currentHealth = maxHealth; // when the game starts. our current health will be the max health.
        healthBar.SetMaxHealth(maxHealth);


        rb = GetComponent<Rigidbody>();
        currentSpeed = walkingSpeed;
        baseLineGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) // if space is pressed. 
        {
           
            
            TakeDamage(1); // take 1 damage.
        }

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

        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody>().velocity = Vector3.up*jumpVelocity;
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

    void TakeDamage(int damage)
    {
        currentHealth -= damage;  // when u take damage the current health will be the current health - damage.
          
        healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

}
