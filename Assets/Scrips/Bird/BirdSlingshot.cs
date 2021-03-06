using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSlingshot : MonoBehaviour
{
    [SerializeField] private LineRender _lineRender;
    [SerializeField] private float _forceMultiplier = 1000f;

    private BirdCollision _birdCollision;
    private Rigidbody2D _rb;
    private Vector2 _startPosition;
    private Vector2 _mousePosition;
    private Vector2 _direction;
    
    private float _maxDistance = 2f;


    private void Start()
    {
        _startPosition = transform.position;
        _birdCollision.transform.position = transform.position;
        Debug.Log(_startPosition);
    }

    #region MouseInput

    private void OnMouseDrag()
    {
        GetMousePosition();
        GetDirection();
        UpdateBirdPosition();
        _lineRender.SimulateArc(_direction, _forceMultiplier,_birdCollision);
    }

    private void OnMouseUp()
    {
        if (_direction.magnitude > 0.5f)
        {
            _birdCollision.SetCollider(true);
            _rb.gravityScale = 1;
            AddForce(_direction);
            _lineRender.ReSetLine();
        }
        else
        {
            ResetBird();
        }
    }

    #endregion

    #region GetPositions
    private void GetMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void GetDirection()
    {
        _direction = _startPosition - _mousePosition;
        _direction = _direction.normalized;

    }
    #endregion
    
    #region BirdManagment
    
    private void UpdateBirdPosition()
    {
        _birdCollision.transform.position = _mousePosition;
        
        if (Vector2.Distance(_startPosition,_mousePosition) > _maxDistance)
        {
            _birdCollision.transform.position = _startPosition - _direction.normalized * _maxDistance;
        }
    }

    private void ResetBird()
    {
        _rb.velocity = Vector2.zero;
        _birdCollision.transform.position = _startPosition;
    }
    
    public void ChangeBird(BirdCollision birdCollision)
    {
        _rb = birdCollision.rb;
        _birdCollision = birdCollision;
        ResetBird();
    }
    
    #endregion

    private void AddForce(Vector2 direction)
    {
        _rb.AddForce(direction * _forceMultiplier);
    }
   
}
