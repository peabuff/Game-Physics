using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class AddForce : MonoBehaviour
{
    [SerializeField] public Vector3 forceVector;

    private PhysicsEngine _physicsEngine;

    private void Start()
    {
        _physicsEngine = gameObject.GetComponent<PhysicsEngine>();
        _physicsEngine.AddForces(forceVector);
    }

    private void FixedUpdate()
    {
        _physicsEngine.AddForces(forceVector);
    }
}
