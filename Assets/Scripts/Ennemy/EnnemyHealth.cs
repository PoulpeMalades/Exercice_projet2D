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

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        _animator.SetTrigger("Death");
        Destroy(gameObject, 1.5f);
    }
}
