using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using Buffs;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Player_Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

namespace UI
{
    public class UIBehaviour : MonoBehaviour
    {
        // надо определиться с тем, как считать высоту, пройденную игроком
        // например, зная скорость движения каждого блока вниз, с той же частотой прибавлять 1 к высоте
        // округлять до целочисленных
        [FormerlySerializedAs("CoinsText")] [SerializeField] private TMP_Text coinsText;
        [FormerlySerializedAs("DiamondsText")] [SerializeField] private TMP_Text diamondsText;
        [FormerlySerializedAs("DistanceText")] [SerializeField] private TMP_Text distanceText;

        [FormerlySerializedAs("StartCoordsX")] [SerializeField] private int pointX;
        [FormerlySerializedAs("StartCoordsY")] [SerializeField] private int pointY;
        
        
        private Player _player;
        private Dictionary<Transform, float> _buffs;

        private const float MaxDelay = 10f;

        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
            _buffs = _player.Effects;
        }

        // Update is called once per frame
        void Update()
        {
            coinsText.text = _player.Coins.ToString();
            diamondsText.text = _player.Diamonds.ToString();
            CheckDelay();
        }

        void CheckDelay()
        {
            foreach (var key in _buffs
                         .OrderBy(x => x.Value)
                         .ToDictionary(x => x.Key, x => x.Value)
                         .Keys
                         .ToList())
            {
                AddBuffToCanvas(key);
                _buffs[key] -= Time.deltaTime;
                // Debug.Log($"{_buffs[key]}");
                if (_buffs[key] < 0)
                {
                    _buffs.Remove(key);
                    key.gameObject.SetActive(false);
                    MoveLeft();
                    continue;
                }
                var imageState = _buffs[key] / MaxDelay;
                key.GetChild(1).GetComponent<Image>().fillAmount = imageState;
            }
        }

        void AddBuffToCanvas(Transform key)
        {
            // добавляет новый бафф справа
            // проверять на наличие баффа в канвасе
            if (!key.gameObject.activeSelf)
            {
                key.gameObject.SetActive(true);
                key.position = new Vector3(_buffs.Count * (150 + key.localScale.x), pointY, key.position.z);
            }
        }

        void MoveLeft()
        {
            // сдвигает список баффов влево
            var counter = 1; // ДА, КАСТЫЛЬ БЕ БЕ БЕ
            foreach (var key in _buffs.Keys)
            {
                key.position = new Vector3(counter * (150 + key.localScale.x), pointY, key.position.z);
                counter++;
            }
        }
    }
}
