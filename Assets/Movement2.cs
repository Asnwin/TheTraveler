using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    static Animator anim;
    public float Speed;
    public float AccelerationFactor;
    public float DecelerationFactor;
    private Vector3 velocity;
    public GameObject charaanim;

    // Update is called once per frame

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Vector3 direction = new Vector3(1f, 0f, 1f).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //charaanim.GetComponent<Animator>().Play("rig|rigAction"); // Anim Run
        }
            // Get the normalized direction vector 
            float xs = Input.GetAxis("Horizontal");
        float zs = Input.GetAxis("Vertical");
        // Debug.Log("XS:" + xs +"ZS:" + zs);         // vector is inside now // 

        

        

        // Compute  Acceleration Vector 
        Vector3 acceleration = new Vector3(xs, 0, zs);
        acceleration.Normalize();



        // Player Face Direction 
        Vector3 movement = new Vector3(xs, 0.0f, zs);
        transform.rotation = Quaternion.LookRotation(movement);
        // compute speed 
        velocity += acceleration * AccelerationFactor * Time.deltaTime;

        // change position
        Vector3 speedVector = velocity * Speed * Time.deltaTime;
        transform.position += speedVector;

        // Deceleration 
        velocity *= DecelerationFactor;



    }
}