using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BirdManager _birdManager;
    [SerializeField] private PigManager _pigManager;
    [SerializeField] private GameObject _winCanves;
    [SerializeField] private GameObject _loseCanves;
    void Start()
    {
        _birdManager.OnBirdDied += Lose;
        _pigManager.OnPigDied += Win;
        _winCanves.SetActive(false);
        _loseCanves.SetActive(false);
    }

    private void Win()
    {
        _winCanves.SetActive(true);
    }

    private void Lose()
    {
        _loseCanves.SetActive(true);
    }
}
