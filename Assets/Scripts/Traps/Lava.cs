using Player_Scripts;
using UnityEngine;

namespace Traps
{
    public class Lava : MonoBehaviour
    {
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(Fields.Tags.Player) && !other.GetComponent<Player>().HasRingLava)
                other.GetComponent<Player>().Death();
        }
    }
}
