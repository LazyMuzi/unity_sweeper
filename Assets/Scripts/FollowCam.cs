using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Quaternion camAngle;

    private void Start()
    {
        var desiredPosition = target.position + offset;
        transform.position = desiredPosition;
        transform.rotation = camAngle;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not set!");
            return;
        }

        var desiredPosition = target.position + offset;
        var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
