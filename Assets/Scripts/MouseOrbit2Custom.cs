using UnityEngine;
 
public class MouseOrbit2Custom : MonoBehaviour
{
    [AddComponentMenu("Camera-Control/Mouse Orbit")]
 
    [SerializeField] private Transform target;
    [SerializeField] private float distance = 10.0f;
    [SerializeField] private float xSpeed = 250.0f;
    [SerializeField] private float ySpeed = 120.0f;
    [SerializeField] private float yMinLimit = -20f;
    [SerializeField] private float yMaxLimit = 80f;
 
    [SerializeField] private float x = 0.0f;
    [SerializeField] private float y = 0.0f;
 
    private Vector3 negativeZDistanceVector = new Vector3(0.0f, 0.0f, -0.0f);
 
    void Start()
    {
        negativeZDistanceVector.z = -distance;
 
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
 
        // Make the rigid body not change rotation
        if (TryGetComponent(out Rigidbody r))
        { r.freezeRotation = true; }
    }
 
    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            distance += Input.mouseScrollDelta.y * -0.2f; // Line added
 
            y = ClampAngle(y, yMinLimit, yMaxLimit);
 
            negativeZDistanceVector.z = -distance;
 
            Quaternion rotation = Quaternion.Euler(y, x, 0f);
            Vector3 position = rotation * negativeZDistanceVector + target.position;
 
            transform.rotation = rotation;
            transform.position = position;
        }
    }
 
    static float ClampAngle(float angle_p, float min_p, float max_p)
    {
        if (angle_p < -360) { angle_p += 360; }
        if (angle_p > 360) { angle_p -= 360; }
        return Mathf.Clamp(angle_p, min_p, max_p);
    }
}