using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigManager : MonoBehaviour
{
    public event Action OnPigDied; 
    [SerializeField] private List<PigHp> _pigs;
    [SerializeField] private ScoreManager _scoreManager;
    
    void Start()
    {
        foreach (var pig in _pigs)
        {
            pig.OnPigDie += RemovePig;
        }
    }

    private void RemovePig(PigHp pig)
    {
        pig.OnPigDie -= RemovePig;
        _scoreManager.AddScore(100);
        _pigs.Remove(pig);

        if (_pigs.Count <= 0)
        {
            OnPigDied?.Invoke();
        }
    }

    public bool PigsRemaind()
    {
        if (_pigs.Count > 0)
            return true;

        return false;
    }
}
