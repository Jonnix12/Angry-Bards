using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private int _cureentLeval = 2;
    private int _LevalSlectIndex = 1;

    public void StartCureentLeaval()
    {
        SceneManager.LoadScene(_cureentLeval);
    }

    public void LoadLevalSlect()
    {
        SceneManager.LoadScene(_LevalSlectIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
