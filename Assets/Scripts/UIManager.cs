using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance
    {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }
            return _instance;
        }
    }

    public Image playerLife;
    public GameObject gameOverObject;
    public GameObject victoryPanelObject;
    public Text pointsText;
    public GameObject PausedMenu;

    //public Button ReloadButton;

    public void SetPlayerLife(float _value) {
        playerLife.fillAmount = _value;
    }

    public void SetPointsText(int _value) {
        pointsText.text = _value.ToString();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void PauseGame(){
        Time.timeScale = 0F;
        PausedMenu.SetActive(true);
    }
    public void resumeGame()
    {
        Time.timeScale = 1F;
        PausedMenu.SetActive(false);
    }

}
