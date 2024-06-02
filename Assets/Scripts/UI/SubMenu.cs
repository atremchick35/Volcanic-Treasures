using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Fields;
using Player = Player_Scripts.Player;

namespace UI
{
    public class SubMenu : MonoBehaviour
    {
        [SerializeField] private bool pauseGame;
        [SerializeField] private GameObject pauseGameMenu;
        [SerializeField] private GameObject deathMenu;
        [SerializeField] private Player player;
        [SerializeField] private TMP_Text totalCoinsText;
        [SerializeField] private TMP_Text totalDiamondsText;
        
        private const float ResumeTimeScale = 1f;
        private const float PauseTimeScale = 0f;
        
        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !deathMenu.activeSelf)
                OnPause(pauseGame);
            CheckPlayer();
        }

        public void OnPause(bool isActive)
        {
            pauseGameMenu.SetActive(isActive);
            Time.timeScale = isActive ? PauseTimeScale : ResumeTimeScale;
            pauseGame = !isActive;
        }

        // public void Resume()
        // {
        //     pauseGameMenu.SetActive(false);
        //     Time.timeScale = ResumeTimeScale;
        //     pauseGame = false;
        // }
        //
        // public void Pause()
        // {
        //     pauseGameMenu.SetActive(true);
        //     Time.timeScale = PauseTimeScale;
        //     pauseGame = true;
        // }

        public void LoadMenu()
        {
            Time.timeScale = ResumeTimeScale;
            SceneManager.LoadScene(Scenes.Menu);
        }

        public void LoadStart()
        { 
            // player.gameObject.SetActive(true);
            SceneManager.LoadScene(Scenes.Block1);
            Time.timeScale = ResumeTimeScale;
        }

        public void CheckPlayer()
        {
            if (!player.gameObject.activeSelf)
            {
                Time.timeScale = 0f;
                deathMenu.SetActive(true);
                totalCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
                totalDiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
            }
        }
    }
}
