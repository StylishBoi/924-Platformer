using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] JumpPadManager _jumpPadManager;
    
    //Determines the jumppad bounciness
    private float bounce = 10f;
    
    //Will animate the jumppad
    private Animator _animator;
    private const string animated = "Bounce";

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            //Play the animation once via the name in the animator
            _animator.Play(animated);
            _jumpPadManager.JumpPadSound();
            
            //Makes the player bounce
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
