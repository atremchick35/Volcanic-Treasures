using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private bool pauseGame;
        [SerializeField] private GameObject pauseGameMenu;
        
        private const float ResumeTimeScale = 1;
        private const float PauseTimeScale = 0;
        
        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseGame)
                    Resume();
                else
                    Pause();
            }
        }

        public void Resume()
        {
            pauseGameMenu.SetActive(false);
            Time.timeScale = ResumeTimeScale;
            pauseGame = false;
        }

        public void Pause()
        {
            pauseGameMenu.SetActive(true);
            Time.timeScale = PauseTimeScale;
            pauseGame = true;
        }

        public void LoadMenu()
        {
            Time.timeScale = ResumeTimeScale;
            SceneManager.LoadScene("Menu");
        }
    }
}
