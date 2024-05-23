using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IScoreable
{
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = float.PositiveInfinity;
    }
    public float OnScore()
    {
        rb.AddTorque(40f,40f,40f, ForceMode.VelocityChange);
        return 1f;
    }
}
