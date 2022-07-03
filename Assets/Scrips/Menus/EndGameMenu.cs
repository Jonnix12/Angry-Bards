using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    private BirdManager _birdManager;
    private MainMenu mainMenu;
    [SerializeField] public GameObject pauseOrFinishedCanvas;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject star0;
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelection()
    {
        StartCoroutine(LoadLevelSelection());
    }

    IEnumerator LoadLevelSelection()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0, LoadSceneMode.Additive);
        yield return null;
        mainMenu = FindObjectOfType<MainMenu>();
        mainMenu.LevelSelection();
        SceneManager.UnloadScene(currentIndex);
    }  
    


    public void ReturnToGame()
    {
        pauseOrFinishedCanvas.SetActive(false);
    }

    public void Win()
    {
        _text.text = "You Won!";
        int pigs = _birdManager.CuntBirds();
        if (pigs == 3)
            star3.SetActive(true);
        else if (pigs == 2)
            star2.SetActive(true);
        else
            star1.SetActive(true);
    }

    public void Lose()
    {
        pauseOrFinishedCanvas.SetActive(true);
        _text.text = "You Lost!";
        star0.SetActive(true);
    }
}
