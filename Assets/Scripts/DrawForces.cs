using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Version 1 of this simple component to draw lines representing force vectors
// Think of them as rocket trails if you like

[DisallowMultipleComponent]
[RequireComponent (typeof(PhysicsEngine))]
public class DrawForces : MonoBehaviour {

	public bool showTrails = true;

	private List<Vector3> _forceVectorList = new List<Vector3>();
	private LineRenderer _lineRenderer;
	private int _numberOfForces;
	
	// Use this for initialization
	void Start () {
		_forceVectorList = GetComponent<PhysicsEngine>().forceVectorList;

		_lineRenderer = gameObject.AddComponent<LineRenderer>();
		_lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
		_lineRenderer.SetColors(Color.yellow, Color.yellow);
		_lineRenderer.SetWidth(0.2F, 0.2F);
		_lineRenderer.useWorldSpace = false;
	}
	
	// Update is called once per frame
	void Update () {
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
		} else {
			_lineRenderer.enabled = false;
		}
	}
}
 