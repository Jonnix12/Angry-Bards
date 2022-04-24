using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _healthy;
    [SerializeField] private Sprite[] _wounded;
    [SerializeField] private Sprite[] _veryWounded;
    
    private Sprite[] _currentState;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _currentState = _healthy;
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        
        while (true)
        {
            yield return waitForSeconds;
            _spriteRenderer.sprite = _currentState[Random.Range(0, 3)];
            yield return waitForEndOfFrame;
        }
    }

    public void GetHurt(int hp)
    {
        switch (hp)
        {
            case 1:
                _currentState = _veryWounded;
                break;
                case 2:
                    _currentState = _wounded;
                    break;
                case 3:
                    _currentState = _healthy;
                    break;
        }
    }
}
