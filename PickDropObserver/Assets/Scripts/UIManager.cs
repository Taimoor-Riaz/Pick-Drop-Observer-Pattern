using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Subject<UIManager>
{
    public GameObject startButton;
    public TextMeshProUGUI remainingDebris;
    public TextMeshProUGUI collectedDebris;
    public Transform debrisObject;
    public GameObject gameOver;
    private void Start()
    {
     //   UpdateValueDebris(0);
    }
    public void StartButtonCalled()
    {
        startButton.SetActive(false);
        OnNotify(CurrentState.pickdebris);
    }

    public void GameStartedCalled()
    {
        OnNotify(CurrentState.start);
    }

    public void GameOverCalled()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
       // OnNotify(CurrentState.gameover);
    }

    public void RestartCalled()
    {
        startButton.SetActive(true);
       
    }

    public void UpdateValueDebris(int value)
    {
        remainingDebris.text = "Debris Remaining : " + value.ToString();
    }

    public void UpdateCollectecDebris(int value)
    {
        collectedDebris.text = "Debris Collected : " + value.ToString();
    }
}
