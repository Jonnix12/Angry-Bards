using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;

    public int Score
    {
        get { return _score; }
    }

    public void AddScore(int amont)
    {
        _score += amont;
        _scoreText.text = _score.ToString();
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
