using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Canvas, MainMenu, StartButton, Title, Options;
    public AudioSource menuMusic, inGameMusic;

    // Start is called before the first frame update
    void Start()
    {
        LoadTitle();
        LoadStart();
    }

    public void LoadMainMenu()
    {
        MainMenu.SetActive(true);
        Options.SetActive(false);
        StartButton.SetActive(false);
        LoadTitle();
    }
    public void LoadOptions()
    {
        Options.SetActive(true);
        MainMenu.SetActive(false);
        Title.SetActive(false);
    }
    public void LoadTitle() => Title.SetActive(true);
    public void LoadStart() => StartButton.SetActive(true);
    public void LoadGame()
    {
        Canvas.SetActive(false);
        PlayerController.canMove = true;
        menuMusic.Stop();
        inGameMusic.Play();
    }
    public void Quit() => Application.Quit();
}
