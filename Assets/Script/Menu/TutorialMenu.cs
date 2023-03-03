using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public string tutorialMenuLevel;

    public string mainMenuLevel;

    public void PlayGame()
    {
        Application.LoadLevel(tutorialMenuLevel);
    }

    public void QuitToMain()
    {
        Application.LoadLevel(mainMenuLevel);
    }
}
