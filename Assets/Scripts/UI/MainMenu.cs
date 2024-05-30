using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            // Загружаем следующую по индексу сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void ExitGame()
        {
            Debug.Log("Game quit");
            Application.Quit();
        }
    }
}
