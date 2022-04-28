using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private List<Bird> _birds;
    [SerializeField] private BirdSlingshot _slingshot;
    private int _currentBirdIndex = 0;
    void Start()
    {
        _slingshot.birdAsShot += NextBird;
        _slingshot.ChangeBird(_birds[0]);
    }

    private void RemoveBird(Bird bird)
    {
        _birds.Remove(bird);

        if (_birds.Count <= 0 )
        {
            Debug.Log("Lose");
        }
    }

    private void NextBird(Bird bird)
    {
        RemoveBird(_birds[0]);
        MoveBireds();
    }
    
    public void MoveBireds()
    {
        Debug.Log("I");
        if (_birds.Count > 0)
        {
            _birds[0].transform.Translate(_slingshot.transform.position * 50f);
        }
    }
    
}
 