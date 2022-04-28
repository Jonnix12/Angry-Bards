using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<PigHp> _pigs;

    void Start()
    {
        foreach (var pig in _pigs)
        {
            pig.PigDie += RemovePig;
        }
    }

    private void RemovePig(PigHp pig)
    {
        pig.PigDie -= RemovePig;
        _pigs.Remove(pig);

        if (_pigs.Count <= 0)
        {
            Debug.Log("Win");
        }
    }
}
