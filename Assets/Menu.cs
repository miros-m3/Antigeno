using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Menu : MonoBehaviour
{
    public AudioSource FX;
    public AudioClip Hoverfx;
    public AudioClip Clickfx;
     public void GetLevel2()
     {
      SceneManager.LoadScene("Nivel2");
    }
    public void GetMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
    public void HoverSound()
    {
        FX.PlayOneShot(Hoverfx);
    }
    public void ClickSound()
    {
        FX.PlayOneShot(Clickfx);
    }
}
