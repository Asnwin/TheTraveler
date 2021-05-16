using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    [Header("Variables")]
    public CharacterController controller;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public GameObject charaanim;

    // jump // 
    public bool playerIsGrounded = false;
    //Vitesse de saut
    public float jumpHeight = 8f;
    //Gravité
    public float gravity;
    //Déplacement
    Vector3 moveDirection;


    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

    }



    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //if (Input.GetKey("z")||Input.GetKey("up"))
        //{
        //charaanim.GetComponent<Animator>().Play("run");
        //}



        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg ; // atan2 is a math function  return the angle between  the x-axis and the vector starting at 0 and terminating at x comma y. 
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            charaanim.GetComponent<Animator>().Play("run"); // Anim Run 
                                                            //sons // 
                                                            // FindObjectOfType<AudioScript>().Play("Running Footsteps Sound effect");

        }
        // jump // 
        // Y = axe haut/bas
        float speedY = moveDirection.y;
        // Est-ce qu'on appuie sur le bouton de saut (ici : Espace)
        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            charaanim.GetComponent<Animator>().Play("jump"); // Anim Jump 
            moveDirection.y = jumpHeight;

        }
        else
        {
            moveDirection.y = speedY;
        }
        //Si le joueur ne touche pas le sol
        if (!controller.isGrounded)
        {
            //Applique la gravité * deltaTime
            //Time.deltaTime = Temps écoulé depuis la dernière frame
            moveDirection.y -= gravity * Time.deltaTime;
        }
        //Applique le mouvement
        controller.Move(moveDirection * Time.deltaTime);
    }
}