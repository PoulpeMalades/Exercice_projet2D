using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    
    public string _newGameLevel;
    
    [Header("IFrames")]
    [SerializeField]private float iFrameTime;
    [SerializeField]private int numberOffFlashes;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private AudioClip audioHit = null;
    private AudioSource _audioSource;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ennemy"))
        {
            Debug.Log("Damage with " + collision.name);
            TakeDamage(5);
            _rigidBody.AddForce(Vector2.left * 2f, ForceMode2D.Impulse);
            _animator.SetTrigger("Hit");
            _audioSource.PlayOneShot(audioHit);
        }
        if (collision.CompareTag("Respawn"))
        {
            _rigidBody.position = new Vector3 (-128.2f,18.34f);
            _rigidBody.linearVelocity = Vector2.zero;
            TakeDamage(5);
        }
    }
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            _animator.SetTrigger("Death");
            Destroy(gameObject,2f);
            Invoke("Destroy", 0.7f);
        }
        if (_rigidBody.position.y <= -10)
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Destroy()
    {
        SceneManager.LoadScene("GameOver");
    }
    
    public IEnumerator KnockBack(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            _rigidBody.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }
}
