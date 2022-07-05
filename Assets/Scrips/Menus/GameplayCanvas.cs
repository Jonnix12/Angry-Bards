using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] public GameObject pauseOrFinishedCanvas;
    [SerializeField] private TextMeshProUGUI _stopMenuText;
    [SerializeField] public TextMeshProUGUI Score;

    public void StopMenu()
    {
        pauseOrFinishedCanvas.SetActive(true);
        _stopMenuText.text = "Stop Menu";
    }
}
