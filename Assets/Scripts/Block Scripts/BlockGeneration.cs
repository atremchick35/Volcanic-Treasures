using UnityEngine;

namespace Block_Scripts
{
    public abstract class Generation : MonoBehaviour
    {
        private void CreateBlock(GameObject randomBlock, Vector3 pos)
        {
            var block = Instantiate(randomBlock, pos, Quaternion.identity);
            var movement = block.AddComponent<BlockMovement>();
            movement.BlockBaseSpeed = blockBaseSpeed;
            movement.BlockSpeedInc = blockSpeedIncrease;
            movement.LavaPosition = lavaPosition;
        }
    }
    public class BlockGeneration : MonoBehaviour
    {
        private GameObject[] _blocks;
        private bool _hasSpawned;
        
        [SerializeField] private float blockSize;
        
        private void Awake() => _blocks = Resources.LoadAll<GameObject>("Blocks");

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && !_hasSpawned)
            {
                _hasSpawned = true;

                var newBlock = Instantiate(_blocks[Random.Range(0, _blocks.Length)],
                    new Vector3(0, gameObject.transform.position.y + blockSize, 0), Quaternion.identity);
                var movement = newBlock.AddComponent<BlockMovement>();
                var thisMovement = gameObject.GetComponentInParent<BlockMovement>();
                
                movement.BlockBaseSpeed = thisMovement.BlockBaseSpeed;
                movement.BlockSpeedInc = thisMovement.BlockSpeedInc;
                movement.LavaPosition = thisMovement.LavaPosition;
            }
        }
    }
}
