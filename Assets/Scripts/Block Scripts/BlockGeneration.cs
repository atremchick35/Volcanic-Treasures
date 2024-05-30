using UnityEngine;

namespace Block_Scripts
{
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
