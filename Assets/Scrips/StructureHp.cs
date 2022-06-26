using System;
using UnityEngine;

public class StructureHp : MonoBehaviour
{
    public int hp;
    [SerializeField] private StructureVisual _animation;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.velocity.magnitude > 1f)
            {
                hp--;
                _animation.UpdateSprite(hp);
                if (hp < 1)
                {
                    gameObject.SetActive(false);                  
                }
            }
        }
    }
}
