using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public VariableJoystick joystick;
    
    private CharacterController _controller;
    private Animator _anim;
    
    private Vector3 _moveDir;
    
    private void Start ()
    {
        TryGetComponent(out _controller);
        TryGetComponent(out _anim);
    }

    private void FixedUpdate ()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        
        _moveDir = new Vector3(horizontal, 0f, vertical).normalized;

        var isRun = _moveDir.magnitude >= 0.1f;
        _anim.SetBool("Run", isRun);
        
        if (!isRun) return;
        
        _moveDir = _moveDir.normalized;
        transform.rotation = Quaternion.LookRotation(_moveDir);
        _controller.Move(_moveDir * moveSpeed * Time.deltaTime);
    }
}
