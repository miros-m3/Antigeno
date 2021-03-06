using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    private bool paused = false;
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
        Time.timeScale = 1F;
        Debug.Log(this.name + " is resumed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void PauseGame(){

        // paused = true;
        Time.timeScale = 0F;
        Debug.Log(this.name + " is paused");
        PausedMenu.SetActive(true);

    }
 
    public void resumeGame()
    {
        // paused = false;
        Time.timeScale = 1F;
        Debug.Log(this.name + " is resumed");
        PausedMenu.SetActive(false);
      
    }
    public void GetMainMenu()
    {
        Time.timeScale = 1F;
        Debug.Log(this.name + " is resumed");
        //paused = false;
        SceneManager.LoadScene("Main Menu");
        
    }

    // private void FixedUpdate(){

    //    if (paused == true){
    //  Time.timeScale = 0F;
    //   Debug.Log(this.name + " is paused")}
    //    if (paused == false){
    //    Time.timeScale = 1F;
    // Debug.Log(this.name + " is resumed");}
    
}
