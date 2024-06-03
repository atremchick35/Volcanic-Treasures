using TMPro;
using UnityEngine;

namespace UI
{
    public class DeathMenu : SceneLoader
    {
        [SerializeField] private TMP_Text totalCoinsText;
        [SerializeField] private TMP_Text totalDiamondsText;
        [SerializeField] private TMP_Text totalDistanceText;
        
        private void Start()
        {
            totalCoinsText.text = PlayerPrefs.GetInt("Coins").ToString();
            totalDiamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
            totalDistanceText.text = PlayerPrefs.GetInt("Distance").ToString();
        }
    }
}
