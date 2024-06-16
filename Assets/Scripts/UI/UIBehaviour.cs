using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Player_Scripts;
using TMPro;

namespace UI
{
    public class UIBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text coinsText;
        [SerializeField] private TMP_Text diamondsText;
        [SerializeField] private TMP_Text distanceText;
        
        private Player _player;
        private Dictionary<Transform, float> _buffs;
        
        private void Start()
        {
            _player = GameObject.FindWithTag(Fields.Tags.PlayerTag).GetComponent<Player>();
            _buffs = _player.Effects;
        }
        
        private void Update()
        {
            coinsText.text = _player.Coins.ToString();
            diamondsText.text = _player.Diamonds.ToString();
            distanceText.text = _player.GetPlayerDistance().ToString();
            CheckDelay();
        }

        private void CheckDelay()
        {
            foreach (var key in _buffs.Keys.ToList())
            {
                AddBuffToCanvas(key);
                _buffs[key] -= Time.deltaTime;
                
                if (_buffs[key] < 0)
                {
                    _buffs.Remove(key);
                    key.gameObject.SetActive(false);
                    MoveLeft();
                    continue;
                }
                
                var imageState = _buffs[key] / Fields.UIBehaviour.MaxDelay;
                key.GetChild(1).GetComponent<Image>().fillAmount = imageState;
            }
        }

        private void AddBuffToCanvas(Transform key)
        {
            // добавляет новый бафф справа
            // проверять на наличие баффа в канвасе
            if (!key.gameObject.activeSelf)
            {
                key.gameObject.SetActive(true);
                var pointX = _buffs.Count * (Fields.UIBehaviour.Space + key.localScale.x);
                key.position = new Vector3(pointX, Fields.UIBehaviour.PointY, key.position.z);
            }
        }

        private void MoveLeft()
        {
            // сдвигает список баффов влево
            var shiftPosition = Fields.UIBehaviour.Shift;
            foreach (var key in _buffs.Keys)
            {
                var pointX = shiftPosition * (Fields.UIBehaviour.Space + key.localScale.x);
                key.position = new Vector3(pointX, Fields.UIBehaviour.PointY, key.position.z);
                shiftPosition++;
            }
        }
    }
}
