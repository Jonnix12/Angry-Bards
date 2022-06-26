using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    [SerializeField] private List<BirdCollision> _birds;
    [SerializeField] private BirdSlingshot _slingshot;
  
    void Awake()
    {
        _slingshot.ChangeBird(_birds[0]);
        
        for (int i = 0; i < _birds.Count; i++)
        {
            _birds[i].OnBirdDispos += NextBird;
        }
    }

    private void RemoveBird(BirdCollision birdCollision)
    {
        _birds.Remove(birdCollision);

        if (_birds.Count <= 0 )
        {
            Debug.Log("Lose");
        }
    }

    private void NextBird(BirdCollision birdCollision)
    {
        RemoveBird(birdCollision);
        _slingshot.ChangeBird(_birds[0]);
        //MoveBirds();
    }
    
    public void MoveBirds()
    {
        if (_birds.Count > 0)
        {
            _birds[0].transform.Translate(_slingshot.transform.position * 50f);
        }
    }
    
}
 