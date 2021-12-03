using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void SetPlayerLife(float _value) {
        playerLife.fillAmount = _value;
    }

    public void SetPointsText(int _value) {
        pointsText.text = _value.ToString();
    }
}
