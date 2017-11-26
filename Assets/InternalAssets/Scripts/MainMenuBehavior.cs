using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public void LoadPlayerSelectionScene()
    {
        SceneManager.LoadScene("PlayersSelectionScene");
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
