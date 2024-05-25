using UnityEngine;

namespace Block_Scripts
{
    public class StartLevelGeneration : MonoBehaviour
    {
        [SerializeField] private float blockSize = 20f;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private GameObject lavaPrefab; // goes after player
        [SerializeField] private float blockBaseSpeed = 1f;
        [SerializeField] private float blockSpeedIncrease = 0.1f; // (m/s^2)
        [SerializeField] private float lavaPosition = -20f;
        [SerializeField] private float lavaOffset = 7f;
        void Start()
        {
            // get all start bloks
            var startBlocks = Resources.LoadAll<GameObject>("StartBlocks");

            // create player
            Instantiate(playerPrefab);

            // create start block
            var firstBlock = Instantiate(startBlocks[Random.Range(0, startBlocks.Length)]);
            var movement = firstBlock.AddComponent<BlockMovement>();
            movement.BlockBaseSpeed = blockBaseSpeed;
            movement.BlockSpeedInc = blockSpeedIncrease;
            movement.LavaPosition = lavaPosition;
        
            // get other blocks
            var otherBlocks = Resources.LoadAll<GameObject>("Blocks");

            // create second block
            var secondBlock = Instantiate(otherBlocks[Random.Range(0, otherBlocks.Length)], new Vector3(0, blockSize, 0), Quaternion.identity);
            movement = secondBlock.AddComponent<BlockMovement>();
            movement.BlockBaseSpeed = blockBaseSpeed;
            movement.BlockSpeedInc = blockSpeedIncrease;
            movement.LavaPosition = lavaPosition;

            // create lava
            Instantiate(lavaPrefab, new Vector3(0, lavaPosition + lavaOffset, 0), Quaternion.identity);
        }
    }
}
