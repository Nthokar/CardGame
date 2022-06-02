using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ima : MonoBehaviour
{
    public void doExitGame()
    {
        Application.Quit();
    }

    public void LoadSampleScene()
    {
        SceneManager.UnloadScene(1);
        SceneManager.LoadScene(0);
    }
}
