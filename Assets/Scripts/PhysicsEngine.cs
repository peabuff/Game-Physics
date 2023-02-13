
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [SerializeField] public float mass = 1f;
    [SerializeField] public Vector3 velocityVector; // Average velocity this FixedUpdate()
    [SerializeField] public List<Vector3> forceVectorList = new List<Vector3>();
    [SerializeField] [ReadOnlyInspector] public Vector3 netForceVector;
    private void FixedUpdate()
    {
        AddForces();
        UpdateVelocity();

        transform.position += velocityVector * Time.deltaTime;
    }

    private void AddForces()
    {
        netForceVector = Vector3.zero;
        
        for (int i = 0; i < forceVectorList.Count; i++)
        {
            netForceVector += forceVectorList[i];
        }
    }

    private void UpdateVelocity()
    {
        //F = m x a;
        //a = F / m;

        Vector3 accelerationVector = netForceVector / mass;
        velocityVector += accelerationVector * Time.deltaTime;

    }
}
