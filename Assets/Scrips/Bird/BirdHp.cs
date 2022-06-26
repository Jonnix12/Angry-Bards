using System;
using UnityEngine;

public class BirdHp : MonoBehaviour
{
    public int hp;
    public event Action<BirdHp> OnbirdDie; 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.velocity.magnitude > 1f)
            {
                hp--;
                
                if (hp < 1)
                {
                    OnbirdDie?.Invoke(this);
                    gameObject.SetActive(false);                  
                }
            }
        }
    }
}
