using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdCollision : MonoBehaviour
{ 
    public event Action<BirdCollision> OnBirdDispos;
    [SerializeField] private CircleCollider2D _collider;
   public Rigidbody2D rb;
   private bool _isTimerStart = false;
   
   private void OnCollisionEnter2D(Collision2D col)
   {
       if (!_isTimerStart)
       {
            StartCoroutine(DisableTime());
            _isTimerStart = true;
       }
   }

   private IEnumerator DisableTime()
   {
      yield return new WaitForSeconds(7f);
      OnBirdDispos?.Invoke(this);
      gameObject.SetActive(false);
      StopAllCoroutines();
   }

   public void SetCollider(bool isOn)
   {
       _collider.enabled = isOn;
   }
}
