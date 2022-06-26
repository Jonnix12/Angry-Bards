using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigManager : MonoBehaviour
{
    [SerializeField] private List<PigHp> _pigs;

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
        _pigs.Remove(pig);

        if (_pigs.Count <= 0)
        {
            Debug.Log("Win");
        }
    }
}
