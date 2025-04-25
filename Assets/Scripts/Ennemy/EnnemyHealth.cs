using UnityEngine;

public class EnnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float MaxHealth = 1f;
    
    private float currentHealth;
    
    private Animator _animator;

    private void Start()
    {
        currentHealth = MaxHealth;
        _animator = GetComponent<Animator>();
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        _animator.SetTrigger("Damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetBool("Death",true);
        Destroy(gameObject, 1f);
    }
}
