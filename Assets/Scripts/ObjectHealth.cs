using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 1f;
    
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}


        
    


