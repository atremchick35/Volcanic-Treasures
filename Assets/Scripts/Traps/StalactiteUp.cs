using Player_Scripts;
using SmoothShakeFree;
using UnityEngine;

namespace Traps
{
    public class StalactiteUp : MonoBehaviour
    {
        [SerializeField] private float gravityScale;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private ShakeBase shaker;
        private bool _isShaking;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.PlayerTag) && !_isShaking)
            {
                _isShaking = true;
                shaker.StartShake();
                Invoke(nameof(DropStalactite), Fields.StalactiteShakeTime);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.collider.CompareTag(Fields.Tags.PlayerTag))
            {
                var player = other.gameObject.GetComponent<Player>();
                if (!player.IsImmortal)
                    other.gameObject.GetComponent<Player>().Death();
            }
            Destroy(gameObject);
        }

        private void DropStalactite()
        {
            audioSource.Play();
            GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        }
    }
}
