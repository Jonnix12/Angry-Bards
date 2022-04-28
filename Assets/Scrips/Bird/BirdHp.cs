using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdHp : MonoBehaviour
{
    public int hp;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.velocity.magnitude > 1f)
            {
                hp--;
                
                if (hp < 1)
                {
                    
                    gameObject.SetActive(false);                  
                }
            }
        }
    }
}
