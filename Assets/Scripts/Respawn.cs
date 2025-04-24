using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if (_rigidBody.position.y <= -8)
        {
            _rigidBody.position = new Vector2(-123.6f, 17.2f);
        }
    }
}
