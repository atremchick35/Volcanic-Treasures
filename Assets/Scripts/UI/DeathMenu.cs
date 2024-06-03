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
            totalCoinsText.GetComponent<CountAnimation>().SetTarget(PlayerPrefs.GetInt("Coins"));
            totalDiamondsText.GetComponent<CountAnimation>().SetTarget( PlayerPrefs.GetInt("Diamonds"));
            totalDistanceText.text = PlayerPrefs.GetInt("Distance").ToString();
        }
    }
}
