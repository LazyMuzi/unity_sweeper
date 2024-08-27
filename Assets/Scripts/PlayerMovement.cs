using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public VariableJoystick joystick;
    
    public float moveSpeed = 10f;
    public float turnSpeed = 20f;
    
    private Animator _anim;
    private Rigidbody _rb;
    private AudioSource _audioSource;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    
    private void Start ()
    {
        TryGetComponent (out _anim);
        TryGetComponent(out _rb);
        TryGetComponent(out _audioSource);
    }

    private void FixedUpdate ()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        
        _movement.Set(horizontal, 0f, vertical);
        _movement.Normalize ();

        var hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        var hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        var isWalking = hasHorizontalInput || hasVerticalInput;
        _anim.SetBool ("IsWalking", isWalking);

        var desiredForward = Vector3.RotateTowards (transform.forward, _movement, turnSpeed * Time.deltaTime, 0f);
        _rotation = Quaternion.LookRotation (desiredForward);

        transform.rotation = _rotation;
        transform.Translate(_movement * moveSpeed * Time.deltaTime);
    }
}
