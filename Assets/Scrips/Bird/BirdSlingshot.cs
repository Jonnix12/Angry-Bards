using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSlingshot : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _forceMultiplier = 1000f;
    
    private Vector2 _startPosition;
    private Vector2 _mousePosition;
    private Vector2 _direction;

    private float _maxDistance = 2f;


    private void Start()
    {
        _startPosition = transform.position;
        Debug.Log(_startPosition);
    }

    private void OnMouseDrag()
    {
        GetMousePosition();
        GetDirection();
        UpdateBirdPosition();
    }

    private void OnMouseUp()
    {
        if (_direction.magnitude > 0.5f)
        {
            _rb.gravityScale = 0.5f;
            AddForce(-_direction);
        }
        else
        {
            ResetBird();
        }
    }

    private void GetMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void GetDirection()
    {
        _direction = _mousePosition -_startPosition;
        
        if (Vector2.Distance(_startPosition,_mousePosition) > _maxDistance)
        {
            Vector2 newDirection = _direction.normalized * _maxDistance;
            _direction = newDirection;
        }
    }

    private void AddForce(Vector2 direction)
    {
        _rb.AddForce(direction * _forceMultiplier);
    }

    private void UpdateBirdPosition()
    {
        transform.position = _direction;
    }

    private void ResetBird()
    {
        _rb.velocity = Vector2.zero;
        transform.position = _startPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position,-_direction);
    }
}
