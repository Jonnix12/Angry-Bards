using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BirdData : MonoBehaviour
{
   public Rigidbody2D rb;
   private bool _isTimerStart = false;
   
   private void OnCollisionEnter2D(Collision2D col)
   {
       if (!_isTimerStart)
       {
        StartCoroutine(DisableTime());
        Debug.Log("I");
        _isTimerStart = true;
       }
   }

   private IEnumerator DisableTime()
   {
      yield return new WaitForSeconds(5f);
      gameObject.SetActive(false);
      StopAllCoroutines();
   }
}
