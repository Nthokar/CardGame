using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.code
{
    public class ima : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadSampleScene()
        {
            SceneManager.LoadScene(1);
        }

        public void StartTestGame()
        {
            SetPlayerDefault();
            GameManager.RestartGame(false);
            LoadSampleScene();
        }
        public void StartSurviveGame()
        {
            SetPlayerDefault();
            GameManager.RestartGame(true);
            LoadSampleScene();
        }
        public void SetPlayerDefault()
        {
            Player.SetDefault();
            CardsStorage.SetDefault();
        }
    }
}
