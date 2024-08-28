using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    public VariableJoystick joystick;
    private CharacterController _controller;
    
    private Vector3 _moveDir;
    
    private void Start ()
    {
        TryGetComponent(out _controller);
    }

    private void FixedUpdate ()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        
        _moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (!(_moveDir.magnitude >= 0.1f)) return;
        
        _moveDir = _moveDir.normalized;
        transform.rotation = Quaternion.LookRotation(_moveDir);
        _controller.Move(_moveDir * moveSpeed * Time.deltaTime);
    }
}
