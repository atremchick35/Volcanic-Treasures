using UnityEngine;

namespace Interfaces
{
    public interface IInteractable
    {
        void OnTriggerEnter2D(Collider2D other);
    }
}
