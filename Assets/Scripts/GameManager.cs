using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    private bool isGameOver = false;
    private int points;
    //private bool crouchInstance = false;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGMAudioClip("Musica1");
        SoundManager.instance.SetBGMVolume(0.25f);
        UIManager.instance.gameOverObject.SetActive(false);
        UIManager.instance.victoryPanelObject.SetActive(false);
        UIManager.instance.SetPointsText(0);
        isGameOver = false;
       // crouchInstance = false;
    }

    public void WinGame() {

        if (isGameOver)
            return;

        UIManager.instance.victoryPanelObject.SetActive(true);
        isGameOver = true;
    }


    public void LoseGame()
    {

        if (isGameOver)
            return;

        UIManager.instance.gameOverObject.SetActive(true);
        isGameOver = true;
    }

    public void AddPoints(int _pointsToAdd) {
        points += _pointsToAdd;
        UIManager.instance.SetPointsText(points);
    }

}
