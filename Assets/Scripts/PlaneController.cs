using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 10f;
    public float gravity = 9.81f;
    public float lift = 10;
    public float rotationSpeed = 10f;

    public float score = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Forward
        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    // Maths in games
    // Mathf.Abs                  - "Makes negative number positive"
    //                            - abs(50) = 50
    //                            - abs(-50) = 50
    // Clamp                      - Ensures a value is between two other values
    //                            -    5 - 10
    //                            -      5
    // Clamp01
    // 
    // 1 - N
    // Invert a number
    // if N is between 0 - 1
    // 1 - 0.75
    // 0.25
    // 
    //
    // Lerp                       - Linear Interpolation
    //                            -     5 - 10
    //                            -       0.5
    //                                =   7.5
    
    // Inverse Lerp
    //                          5 - 10
    //                            7.5
    //                             0.5
    
    // Sin/Cos                    - waves
    //
    // Dot product                - How much do vectors point in he same direction
    //                              - from 1 to -1
    // Cross product - X
    //


    void FixedUpdate()
    {
        //Input
        float input = Input.GetAxisRaw("Vertical");
        rb.AddTorque(transform.right * rotationSpeed * input, ForceMode.Acceleration);
        //Adds rotation


        //Lift
        //float dot = Vector3.Dot(transform.forward, Vector3.up);
        //dot = 1 - Mathf.Abs(dot);
        //float liftResult = lift * dot;
        rb.AddForce(transform.up * lift * SpeedMultiplier(), ForceMode.Acceleration);

        //Gravity
        rb.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        //Drag
        rb.AddForce(-transform.forward * 1f * SpeedMultiplier(), ForceMode.Acceleration);

        //Turn Drag
        float result = 1 - Vector3.Dot(rb.velocity.normalized, transform.forward); 
        rb.AddForce(-transform.forward * 1f * result, ForceMode.Acceleration);

        //Velocity direction moves to forward direction
        rb.velocity = Vector3.Lerp(rb.velocity.normalized, transform.forward, Time.deltaTime).normalized 
                      * rb.velocity.magnitude;
    }
    float SpeedMultiplier()
    {
        return Mathf.InverseLerp(0, 10,rb.velocity.magnitude );   
    }


    private void OnTriggerEnter(Collider other)
    {
        IScoreable scoreable = other.GetComponent<IScoreable>();
        if (scoreable != null)
        {
            score += scoreable.OnScore();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
       IScoreable scoreable = other.gameObject.GetComponent<IScoreable>();
        if (scoreable != null)
        {
           score += scoreable.OnScore();
        }
    }
}








