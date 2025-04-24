using System;
using UnityEngine;
using UnityEngine.Splines;

public class HitBoxRotate : MonoBehaviour
{
    private float _vector2AttackPostion;
    bool attack = Input.GetButton("Fire1");
    bool attack2 = Input.GetButton("Fire2");
    private void Start()
    { 
        //_vector2AttackPosition = ;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        
        if (horizontal>0)
        {
            transform.localPosition = new Vector2(0.8f, 0.7f);
        }
        else if (horizontal < 0)
        {
            transform.localPosition = new Vector2(-0.8f, 0.7f);
        }
        
    }

    
}
