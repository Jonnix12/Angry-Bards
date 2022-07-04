using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PigHp : MonoBehaviour
{
    public event Action<PigHp> OnPigDie;

    public int hp;
    [SerializeField] private CharacterAnimation characterAnimation;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.velocity.magnitude > 1.5f)
            {
                hp -= 3;
                characterAnimation.GetHurt(hp);
            }
            else if (rb.velocity.magnitude > 1f)
            {
                hp -= 2;
                characterAnimation.GetHurt(hp);
            }
            else if(rb.velocity.magnitude > 0.5f)
            {
                hp--;
                characterAnimation.GetHurt(hp);
            }
            
            if (hp < 1)
            {
                OnPigDie?.Invoke(this);
                gameObject.SetActive(false);                  
            }
        }
    }
}
