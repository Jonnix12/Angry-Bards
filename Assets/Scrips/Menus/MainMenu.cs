using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _homeScreen;
    [SerializeField] private GameObject _levelSelection;

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    
    public void HomeScreen()
    {
        _homeScreen.SetActive(true);
        _levelSelection.SetActive(false);
    }

    public void QuickLoad()
    {
        int loadSceneInd = SaveAndLoad.GetSceneIndex();
        SceneManager.LoadScene(loadSceneInd);
    }

    public void LevelSelection()
    {
        _levelSelection.SetActive(true);
        _homeScreen.SetActive(false);
    }
}
