using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float runForce = 2f;

    private float enemyTurn;
    private Rigidbody2D _rb;
    private float _horizontalVelocity=1;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        
        //Turns the enemy based on the direction they're moving
        if (_rb.linearVelocityX < 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (_rb.linearVelocityX > 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        
        //Makes the enemy move
        _rb.linearVelocityX = _horizontalVelocity * runForce;
        
        //Updates cooldown timer
        enemyTurn+=Time.deltaTime;

        //Verify if 2 seconds passed, if they passed, change the direction to the opposite one
        if (enemyTurn > 2.0f)
        {
            switch (_horizontalVelocity)
            {
                case -1 :
                    _horizontalVelocity = 1;
                    break;
                case 1:
                    _horizontalVelocity = -1;
                    break;
            }
            
            //Reset the timer
            enemyTurn = 0f;
        }
    }
    
    
}
