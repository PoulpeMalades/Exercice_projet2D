using System;
using UnityEngine;

public class HitBoxRotate : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
            
            
        if (horizontal > 0)
            _spriteRenderer.flipX = _spriteRenderer.flipX;
        else if (horizontal < 0)
            _spriteRenderer.flipX = _spriteRenderer.flipX;
    }

    
}
