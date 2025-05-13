using UnityEngine;
using UnityEngine.SceneManagement;


public class nextLevel : MonoBehaviour
{
    
    private Rigidbody2D _rigidBody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
}
