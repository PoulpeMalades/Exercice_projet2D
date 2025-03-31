using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float AttackCooldown;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _attackTimer;
    private bool _isAttacking;

    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool attack = Input.GetButton("Fire1");
        
        // Horizontal movement$
        if (_attackTimer >= AttackCooldown)
        {
            transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);
        }
        
        // Jump force
        if (isJumping && _rigidBody.linearVelocity.y == 0 )
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
            _animator.SetBool("Jump", true);
        }
        if (_rigidBody.linearVelocity.y < 0)
        {
             _animator.SetBool("Jump", false);
        }

        if (attack && _attackTimer >= AttackCooldown)
        {
            _attackTimer = 0;
            _animator.SetBool("attack", true);
            transform.Translate(0, 0, 0);
        }
        else
        {
            _attackTimer += Time.deltaTime;
            _animator.SetBool("attack",false);
        }
        
        //     
         // if (isJumping && _rigidBody.linearVelocity.y < 0)
        // {
        //     _animator.SetBool("Jump", false);
        // }
             
           
        
        //Animation update
        _animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
       
        
        //Flipping sprite
        if (horizontal > 0)
            _spriteRenderer.flipX = false;
        else if (horizontal < 0)
            _spriteRenderer.flipX = true;
        
    }
    
}
