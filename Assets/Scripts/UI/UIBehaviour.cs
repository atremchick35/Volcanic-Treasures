using System;
using System.Collections.Generic;
using Buffs;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Player_Scripts;
using TMPro;
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

        [FormerlySerializedAs("Boots")] [SerializeField] private GameObject boots;
        [FormerlySerializedAs("Helmet")] [SerializeField] private GameObject helmet;
        [FormerlySerializedAs("LavaRing")] [SerializeField] private GameObject lavaRing;
        
        private Player _player;
        private Dictionary<Image, float> _buffs;

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
            foreach (var key in _buffs.Keys)
            {
                if (Mathf.Approximately(_buffs[key], MaxDelay))
                {
                    AddBuffToCanvas();
                    continue;
                }
                _buffs[key] -= Time.deltaTime;
                if (_buffs[key] < 0)
                {
                    _buffs.Remove(key);
                    MoveLeft();
                    continue;
                }
                var imageState = _buffs[key] / MaxDelay;
                key.fillAmount = imageState;
            }
        }

        void AddBuffToCanvas()
        {
            // добавляет новый бафф справа
            // проверять на наличие баффа в канвасе
        }

        void MoveLeft()
        {
            // сдвигает список баффов влево
        }
    }
}
