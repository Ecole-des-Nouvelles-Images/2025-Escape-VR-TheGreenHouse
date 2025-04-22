using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartMenu : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject options;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button optionButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;

    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();
        
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(EnableOption);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        HideAll();
        SceneTransitionManager.singleton.GoToSceneAsync(1);
    }

    private void HideAll()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(false);
    }

    private void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        options.SetActive(false);
        about.SetActive(false);
    }

    private void EnableOption()
    {
        mainMenu.SetActive(false);
        options.SetActive(true);
        about.SetActive(false);
    }

    private void EnableAbout()
    {
        mainMenu.SetActive(false);
        options.SetActive(false);
        about.SetActive(true);
    }
}
