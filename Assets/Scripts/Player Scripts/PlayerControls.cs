using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerControls : MonoBehaviour
{
    //Determines the character base values
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _runForce = 10f;
    
    //Takes in different files to use functions in it
    [SerializeField] ContactDetector _isGrounded;
    [SerializeField] AudioManager _audioManager;
    
    //Takes in compoments to animate and move
    private Rigidbody2D _rb;
    private Animator _animator;
    
    private const string _horizontal = "Horizontal";
    
    bool _isJumping;
    private float _horizontalVelocity;
    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (_isGrounded.ContactDectected)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
        //Verify if character can jump or not
        if (_isJumping && coyoteTimeCounter>0f)
        {
            _rb.linearVelocity=new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
        
        //Makes the player move
        _rb.linearVelocityX = _horizontalVelocity * _runForce;
        
        //Set walking OR idle animation based on the velocity
        _animator.SetFloat(_horizontal, Math.Abs(_rb.linearVelocityX));
        
        //Turns the character based on the direction they're moving
        if (_rb.linearVelocityX < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_rb.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //The jump is active
        if (context.started)
        {
            _audioManager.PlaySfx(_audioManager.jumpSFX);
            _isJumping = true;
        }

        //The jump isn't active
        if (context.canceled)
        {
            _isJumping = false;
        }
    }

    private void OnRun(InputAction.CallbackContext context)
    {
        //Intakes the player input for character speed
        _horizontalVelocity=context.ReadValue<float>();
    }
    
    //4 - Start score and UI
    //5 - Camera blocking (Not too high or too low)
}
