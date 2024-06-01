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
        
        private const float ResumeTimeScale = 1f;
        private const float PauseTimeScale = 0f;
        
        private void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseGame)
                    Resume();
                else
                    Pause();
            }
            CheckPlayer();
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
            SceneManager.LoadScene(Scenes.Menu);
        }

        public void LoadStart()
        {
            Time.timeScale = ResumeTimeScale;
            player.gameObject.SetActive(true);
            SceneManager.LoadScene(Scenes.Block1);
        }

        public void CheckPlayer()
        {
            // в случае смерти будем работать тут
            // останавливаем время
            // загружаем экран смерти
            // экран смерти должен включать в себя: кнопку перехода в меню и кнопку начать заново
            // так же экран смерти показывает набранные очки, монеты и всё остальное
            // таблица рекордов: каким-то образом копить результаты в список и выводить их каждый раз на экран
            // можно сделать переход из меню в таблицу рекордов
            // можно создать отдельный класс player stats, который повесить на какой-то сохраняющийся объект,
            // в котором будут все статы, обновляющиеся через циклы игры
            if (!player.gameObject.activeSelf)
            {
                Time.timeScale = 0f;
                deathMenu.SetActive(true);
            }
        }
    }
}
