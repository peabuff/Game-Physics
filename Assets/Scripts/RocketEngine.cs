using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{
    [SerializeField] public float fuelMass;             //kg
    [SerializeField] public float maxThrust;            //kilo Newton -> kN -> [F = m x a] -> [kN = kg x m x s^-2] -> [kN = kg x m/s^2]
    [SerializeField] public float thrustPercent;        // [none]
    [SerializeField] public Vector3 thrustUnitVector;   // [none]
    
    private PhysicsEngine _physicsEngine;

    private void Start()
    {
        _physicsEngine = gameObject.GetComponent<PhysicsEngine>();
        _physicsEngine.AddForces(thrustUnitVector);
    }

    private void FixedUpdate()
    {
        _physicsEngine.AddForces(thrustUnitVector);
    }
}
