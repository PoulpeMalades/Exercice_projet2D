using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    
    void Update()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Attack")
                Destroy(gameObject);
        }
    }
}


        
    


