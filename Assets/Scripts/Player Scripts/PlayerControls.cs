using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _runForce = 10f;
    [SerializeField] private float _wallJumpForce = 1f;
    
    [SerializeField] ContactDetector _isGrounded;
    [SerializeField] DangerDetector _isDead;
    [SerializeField] WallContactDetector _isLWalled;
    [SerializeField] WallContactDetector _isRWalled;
    
    [SerializeField] AudioManager _audioManager;
    
    private Rigidbody2D _rb;
    
    bool _isJumping;
    private float _horizontalVelocity;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Verify if character has died or not
        if (_isDead.DangerDetected)
        {
            Debug.Log("Death occured = Teleportation !!!!!!");
            
            transform.position = new Vector3(-9.15f,0f,0f);
        }
        
        //Verify if character can jump or not
        if (_isJumping && _isGrounded.ContactDectected)
        {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
        
        //Verify if character can walljump or not
        else if (_isJumping && _isLWalled.WallContactDectected || _isJumping && _isRWalled.WallContactDectected)
        {
            _rb.AddForce(Vector2.up * _wallJumpForce, ForceMode2D.Impulse);
        }
        //Makes the character move based on input
        _rb.linearVelocityX = _horizontalVelocity * _runForce;

        //Turns the character based on the direction they're moving
        if (_rb.linearVelocityX < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (_rb.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
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
    
    //1 - Fix score
    //2 - Add audio
    //3 - Add tremplin
    //4 - Start score and UI
    //5 - Camera blocking (Not too high or too low)
}
