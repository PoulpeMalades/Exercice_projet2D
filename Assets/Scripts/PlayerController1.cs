using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    public float AttackCooldown = 1;
    public float JumpCooldown;
    public float Attack2Cooldown = 2;
    
    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private float _attackTimer;
    private bool _isAttacking;
    private float _attack2Timer;
    
    private float _jumpTimer;
    
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;

    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        bool isJumping = Input.GetButtonDown("Jump");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool attack = Input.GetButton("Fire1");
        bool attack2 = Input.GetButton("Fire2");
        
        // Horizontal movement$
        if (_attackTimer >= AttackCooldown)
        {
            transform.Translate(horizontal * Time.deltaTime * MoveSpeed, 0, 0);
        }
        
        // Jump force
        if (isJumping && _rigidBody.linearVelocity.y == 0 && _jumpTimer >= JumpCooldown)
        {
            _rigidBody.AddForce(Vector2.up * JumpForce);
            _animator.SetBool("Jump", true);
            _jumpTimer = 0;
        }
        else
        {
            _jumpTimer += Time.deltaTime;
            _animator.SetBool("Jump", false);
        }
        if (_rigidBody.linearVelocity.y < 0)
        {
             // _animator.SetFloat(, velocityY);
        }

        if (attack && _attackTimer >= AttackCooldown && _attack2Timer >= Attack2Cooldown)
        {
            _attackTimer = 0;
            _animator.SetBool("attack", true);
            // transform.Translate(0, 0, 0);
        }
        else
        {
            _attackTimer += Time.deltaTime;
            _animator.SetBool("attack",false);
        }
        if ( attack2 && _attack2Timer>=Attack2Cooldown && _attackTimer >= AttackCooldown)
        {
            _attackTimer = 0;
            _attack2Timer = 0;
            _animator.SetBool("attack2", true);
            // transform.Translate(0, 0, 0);
        }
        else
        {
            _attack2Timer += Time.deltaTime;
            _animator.SetBool("attack2", false);
        }

        // if (isJumping && isGrounded)
        // { 
        //     _rigidBody.AddForce(Vector2.up * JumpForce);
        //     _animator.SetBool("Jump", true);
        // }



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
        
        {
            if (Input.GetKeyDown(KeyCode.H)) ;
            {
                TakeDamage(20);
            }
            if (currentHealth == 0)
            {
                _animator.SetTrigger("death");
            }
           
        
        
        
        
        }

        void TakeDamage(int damage)
        {
            // currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        
        }
        
    }
    
}
