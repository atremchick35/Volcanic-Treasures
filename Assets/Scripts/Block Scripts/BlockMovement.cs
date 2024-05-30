using UnityEngine;

namespace Block_Scripts
{
    public class BlockMovement : MonoBehaviour
    {
        // [FormerlySerializedAs("Block Speed Increase Rate")] [SerializeField] private float blockSpeedInc = 0.5f; // (m / s^2)
        // [FormerlySerializedAs("Base Block Movement Speed")] [SerializeField] private float blockBaseSpeed = 5f;
        public float BlockSpeedInc { get; set; } // (m / s^2)
        public float BlockBaseSpeed { get; set; }
        public float LavaPosition { get; set; }
        
        private Transform _transform;

        private void Awake() => _transform = gameObject.GetComponent<Transform>();

        // Update is called once per frame  
        private void Update()
        {
            // Получить текущую скорость лавы
            var blockSpeed = BlockBaseSpeed + Time.timeSinceLevelLoad * BlockSpeedInc;

            // Установить текущую позицию блока
            var position = _transform.position;
            position = new Vector3(position.x, position.y - (blockSpeed * Time.deltaTime), position.z);
            _transform.position = position;
            
            if (_transform.position.y < LavaPosition)
                Destroy(gameObject);
        }
    }
}
