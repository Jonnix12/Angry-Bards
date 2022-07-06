using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField]
    private BirdManager _birdManager;
    private MainMenu mainMenu;
    [SerializeField] public GameObject pauseOrFinishedCanvas;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject star0;
    [SerializeField] private GameObject star1;
    [SerializeField] private GameObject star2;
    [SerializeField] private GameObject star3;

    private int sceneIndex;

    private void Start()
    {
        sceneIndex =SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SaveAndLoad.SaveSceneIndex(3);
            SceneManager.LoadScene(0);
        }

        else
        {
            SaveAndLoad.SaveSceneIndex(sceneIndex+1);
            SceneManager.LoadScene(sceneIndex+1);
        }
    }

    public void HomeScreen()
    {
        SaveAndLoad.SaveSceneIndex(sceneIndex);
        SceneManager.LoadScene(0);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelection()
    {
        SaveAndLoad.SaveSceneIndex(sceneIndex);
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
    
    public void StopMenu()
    {
        pauseOrFinishedCanvas.SetActive(true);
        _text.text = "Stop menu";
    }

    public void ReturnToGame()
    {
        pauseOrFinishedCanvas.SetActive(false);
    }

    public void Win()
    {
        _text.text = "You Won!";
        int birds = _birdManager.CuntBirds();
        if (birds == 3)
            star3.SetActive(true);
        else if (birds == 2)
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
