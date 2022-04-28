using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private List<BirdData> _birds;
    [SerializeField] private BirdSlingshot _slingshot;
    void Start()
    {
        _slingshot.birdAsShot += RemoveBird;
        _slingshot.ChangeBird(_birds[0]);
    }

    private void RemoveBird(BirdData bird)
    {
        _birds.Remove(bird);

        if (_birds.Count <= 0 )
        {
            Debug.Log("Lose");
        }
    }
    
}
