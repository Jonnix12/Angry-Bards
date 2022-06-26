using UnityEngine;

public class StructureVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Sprite _currentSprite;

    private void Start()
    {
        UpdateSprite(3);
    }

    public void UpdateSprite(int hp)
    {
        switch (hp)
        {
            case 1:
                _currentSprite = _sprites[2];
                break;
            case 2:
                _currentSprite = _sprites[1];
                break;
            case 3:
                _currentSprite = _sprites[0];
                break;
        }

        _spriteRenderer.sprite = _currentSprite;
    }
}
