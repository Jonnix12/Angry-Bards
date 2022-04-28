using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PigHp : MonoBehaviour
{
    public Action<PigHp> PigDie;
    
    public int hp;
    [SerializeField] private PigAnimation _pigAnimation;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.velocity.magnitude > 1f)
            {
                hp--;
                _pigAnimation.GetHurt(hp);
                
                if (hp < 1)
                {
                    PigDie?.Invoke(this);
                    gameObject.SetActive(false);                  
                }
            }
        }
    }
}
