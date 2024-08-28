using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Quaternion camAngle;

    private void Start()
    {
        // 시작 시 카메라 위치와 회전 설정
        var desiredPosition = target.position + offset;
        transform.position = desiredPosition;
        transform.rotation = camAngle; // 아이소메트릭 뷰 각도 설정
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
