using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _healthy;
    [SerializeField] private Sprite[] _wounded;
    [SerializeField] private Sprite[] _veryWounded;
    
    private Sprite[] _currentState;
    
    WaitForSeconds waitForSecondsForAnimation;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _currentState = _healthy;
        waitForSecondsForAnimation = new WaitForSeconds(1);
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        while (true)
        {
            yield return waitForSecondsForAnimation;
            _spriteRenderer.sprite = _currentState[Random.Range(0, 3)];
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
