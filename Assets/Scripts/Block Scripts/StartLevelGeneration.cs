using UnityEngine;

namespace Block_Scripts
{
    // Скрипт начинает генерировать блоки (Старт игры)
    public class StartLevelGeneration : Generation
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject lavaPrefab;
        
        private void Awake()
        {
            // Получение всех стартовых "блоков"
            var startBlocks = Resources.LoadAll<GameObject>(Fields.Paths.StartBlocks);

            // Создание игрока
            Instantiate(playerPrefab);

            // Создание стартового "блока"
            CreateBlock(startBlocks[Random.Range(0, startBlocks.Length)], Vector3.zero);
        
            // Получение других "блоков"
            var otherBlocks = Resources.LoadAll<GameObject>(Fields.Paths.Blocks);

            // Создание второго "блока"
            var pos = new Vector3(0, Fields.Generation.BlockSize, 0);
            CreateBlock(otherBlocks[Random.Range(0, otherBlocks.Length)], pos);

            // Создание лавы
            pos = new Vector3(0, Fields.Generation.LavaPosition + Fields.Generation.LavaOffset, 0);
            Instantiate(lavaPrefab, pos, Quaternion.identity);
        }
    }
}
