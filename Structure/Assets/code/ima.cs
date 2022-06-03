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

        public void SetPlayerDefault()
        {
            Player.SetDefault();
            GameManager.RestartGame();
        }
    }
}
