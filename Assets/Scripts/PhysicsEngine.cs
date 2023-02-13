using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [SerializeField] public Vector3 velocityVector; // Average velocity this FixedUpdate()
    [SerializeField] public List<Vector3> forceVectorList = new List<Vector3>();
    private Vector3 _netForceVector;
    private void FixedUpdate()
    {
        AddForces();
        
        if (_netForceVector == Vector3.zero)
        {
            transform.position += velocityVector * Time.deltaTime;
        }
        else
        {
            Debug.LogError("We have a net force = " +_netForceVector);
        }
    }

    private void AddForces()
    {
        _netForceVector = Vector3.zero;
        
        for (int i = 0; i < forceVectorList.Count; i++)
        {
            _netForceVector += forceVectorList[i];
        }
    }
}
