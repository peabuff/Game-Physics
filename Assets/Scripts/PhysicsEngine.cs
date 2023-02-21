
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
    [SerializeField] public float mass = 1f;        // [kg]
    [SerializeField] public Vector3 velocityVector; // [m/s] -> [m x s^-1]
    [ReadOnlyInspector]
    [SerializeField] public Vector3 netForceVector; // kN -> [kg x m x s^-2]
    [SerializeField] public bool showTrails = true;
    
    private List<Vector3> _forceVectorList = new List<Vector3>();
    private LineRenderer _lineRenderer;
    private int _numberOfForces;
    
    private void Start () 
    {
        SetUpThrustTrails();
    }
    private void FixedUpdate()
    {
        RenderTrails();
        UpdatePosition();
    }

    public void AddForces(Vector3 forceVector)
    {
        _forceVectorList.Add(forceVector); 
    }
    

    private void UpdatePosition()
    {
        //Sum the forces and clear the list
        netForceVector = Vector3.zero;
        
        for (int i = 0; i < _forceVectorList.Count; i++)
        {
            netForceVector += _forceVectorList[i];
        }
        _forceVectorList.Clear();
        
        //Calculate position change due to net force
        //F = m x a => a = F / m

        Vector3 accelerationVector = netForceVector / mass;
        velocityVector += accelerationVector * Time.deltaTime;
        transform.position += velocityVector * Time.deltaTime;

    }

    /// <summary>
    ///  Code for drawing thrust trails
    /// </summary>
    private void SetUpThrustTrails()
    {
        _lineRenderer = gameObject.AddComponent<LineRenderer>();
        _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.SetColors(Color.yellow, Color.yellow);
        _lineRenderer.SetWidth(0.2F, 0.2F);
        _lineRenderer.useWorldSpace = false;
    }
    
    private void RenderTrails () 
    {
        if (showTrails) {
            _lineRenderer.enabled = true;
            _numberOfForces = _forceVectorList.Count;
            _lineRenderer.SetVertexCount(_numberOfForces * 2);
            int i = 0;
            foreach (Vector3 forceVector in _forceVectorList) {
                _lineRenderer.SetPosition(i, Vector3.zero);
                _lineRenderer.SetPosition(i+1, -forceVector);
                i = i + 2;
            }
        } 
        else 
        {
            _lineRenderer.enabled = false;
        }
    }
}
