using UnityEngine;

namespace Block_Scripts
{
    public abstract class Generation : MonoBehaviour
    {
        protected static void CreateBlock(BlockMovement currMovement, GameObject randomBlock, Vector3 pos)
        {
            var block = Instantiate(randomBlock, pos, Quaternion.identity);
            var movement = block.AddComponent<BlockMovement>();
            
            movement.BlockBaseSpeed = currMovement.BlockBaseSpeed;
            movement.BlockSpeedInc = currMovement.BlockSpeedInc;
            movement.LavaPosition = currMovement.LavaPosition;
        }
    }
    
    public class BlockGeneration : Generation
    {
        private GameObject[] _blocks;
        private bool _hasSpawned;
        
        private void Awake() => _blocks = Resources.LoadAll<GameObject>(Fields.Paths.Blocks);

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Fields.Tags.PlayerTag) && !_hasSpawned)
            {
                _hasSpawned = true;
                
                var currMovement = GetComponentInParent<BlockMovement>();
                var pos = new Vector3(0, transform.position.y + Fields.Generation.BlockSize, 0);
                CreateBlock(currMovement, _blocks[Random.Range(0, _blocks.Length)], pos);
            }
        }
    }
}
