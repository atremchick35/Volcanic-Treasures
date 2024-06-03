using System;
using UnityEngine;
using Player = Player_Scripts.Player;

namespace UI
{
    public class SubMenu : SceneLoader
    {
        [SerializeField] private bool pauseGame;
        [SerializeField] private GameObject pauseGameMenu;
        [SerializeField] private Player player;

        private void Start() => player.DeathEvent += OnDeathUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPause(pauseGame);
        }

        public void OnPause(bool isActive)
        {
            pauseGameMenu.SetActive(isActive);
            Time.timeScale = isActive ? Fields.UIBehaviour.PauseTimeScale : Fields.UIBehaviour.ResumeTimeScale;
            pauseGame = !isActive;
        }
        
        private void OnDeathUI(object sender, EventArgs e)
        {
            Time.timeScale = Fields.UIBehaviour.PauseTimeScale;
            LoadSceneByName("DeathScene");
        }
    }
}
