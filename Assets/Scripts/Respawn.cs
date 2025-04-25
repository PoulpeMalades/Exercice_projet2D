using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Respawn : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
         {
             rb = GetComponent<Rigidbody2D>();
         }

    private void Update()
    {
        if (rb.position.y <= -10)
        {
            rb.position = new Vector2(-128.2f,18.34f);
            rb.linearVelocity = Vector2.zero;
        }
    }
}
