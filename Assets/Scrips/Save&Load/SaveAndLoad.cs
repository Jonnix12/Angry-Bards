using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    static public void SaveSceneIndex(int scene)
    {
        PlayerPrefs.SetInt("Last Scene", scene);
    }

    static public int GetSceneIndex()
    {
        int  indx= PlayerPrefs.GetInt("Last Scene");
        return indx;
    }
}
