using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdManager _birdManager;
    [SerializeField] private PigManager _pigManager;
    [SerializeField] private EndGameMenu _stopGameOverMenuText;

    private bool _isGameOver = false;
    void Start()
    {
        _birdManager.OnBirdDied += Lose;
        _pigManager.OnPigDied += Win;
        _stopGameOverMenuText.pauseOrFinishedCanvas.SetActive(false);
    }

    private void Win()
    {
        if(!_isGameOver)
        {
            _stopGameOverMenuText.pauseOrFinishedCanvas.SetActive(true);
            _isGameOver = true;
           _stopGameOverMenuText.Win();
        }
    }

    private void Lose()
    {
        if (!_isGameOver)
        {
            _stopGameOverMenuText.pauseOrFinishedCanvas.SetActive(true);
            _isGameOver = true;
            _stopGameOverMenuText.Lose();
        }
    }
}
