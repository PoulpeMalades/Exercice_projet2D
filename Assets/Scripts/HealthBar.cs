using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    
    public string _newGameLevel;
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ennemy")
        {
            TakeDamage(5);
            //_rigidBody.AddForce(Vector3.left * 2f, ForceMode2D.Impulse);
            _animator.SetTrigger("Hit");
        }
    }
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            _animator.SetTrigger("Death");
            Destroy(gameObject,2f);
            Invoke("Destroy", 0.7f);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Heal(20);
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

    public void Heal(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void Destroy()
    {
        SceneManager.LoadScene("GameOver");
    }
}
