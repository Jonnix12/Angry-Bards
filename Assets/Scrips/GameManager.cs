using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdManager _birdManager;
    [SerializeField] private PigManager _pigManager;
    [SerializeField] private EndGameMenu _gameOverMenu;

    private bool _isGameOver = false;
    void Start()
    {
        _birdManager.OnBirdDied += Lose;
        _pigManager.OnPigDied += Win;
        _gameOverMenu.endGameCanvas.SetActive(false);
    }

    private void Win()
    {
        if(!_isGameOver)
        {
            _isGameOver = true;
           _gameOverMenu.Win();
        }
    }

    private void Lose()
    {
        if (!_isGameOver)
        {
            _isGameOver = true;
            _gameOverMenu.Lose();
        }
    }
}
