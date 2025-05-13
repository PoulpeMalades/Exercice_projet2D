using System;
using UnityEngine;
using UnityEngine.Splines;

public class HitBoxRotate : MonoBehaviour
{
    private float _vector2AttackPostion;
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
