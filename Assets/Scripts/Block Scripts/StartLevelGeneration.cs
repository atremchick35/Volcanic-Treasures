using UnityEngine;

namespace Block_Scripts
{
    // Скрипт начинает генерировать блоки (Старт игры)
    public class StartLevelGeneration : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject lavaPrefab; // Следует за игрком
        
        [SerializeField] private float blockSize = 20f;
        [SerializeField] private float blockBaseSpeed = 1f;
        [SerializeField] private float blockSpeedIncrease = 0.1f; // (m/s^2)
        [SerializeField] private float lavaPosition = -20f;
        [SerializeField] private float lavaOffset = 7f;
        
        private void Awake()
        {
            // Получение всех стартовых "блоков"
            var startBlocks = Resources.LoadAll<GameObject>("StartBlocks");

            // Создание игрока
            Instantiate(playerPrefab);

            // Создание стартового "блока"
            CreateBlock(startBlocks[Random.Range(0, startBlocks.Length)], new Vector3(0, 0, 0));
        
            // Получение других "блоков"
            var otherBlocks = Resources.LoadAll<GameObject>("Blocks");

            // Создание второго "блока"
            CreateBlock(otherBlocks[Random.Range(0, otherBlocks.Length)], new Vector3(0, blockSize, 0));

            // Создание лавы
            Instantiate(lavaPrefab, new Vector3(0, lavaPosition + lavaOffset, 0), Quaternion.identity);
        }
        
        private void CreateBlock(GameObject randomBlock, Vector3 pos)
        {
            var block = Instantiate(randomBlock, pos, Quaternion.identity);
            var movement = block.AddComponent<BlockMovement>();
            movement.BlockBaseSpeed = blockBaseSpeed;
            movement.BlockSpeedInc = blockSpeedIncrease;
            movement.LavaPosition = lavaPosition;
        }
    }
}
