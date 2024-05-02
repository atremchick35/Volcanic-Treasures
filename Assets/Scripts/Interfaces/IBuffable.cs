using Player_Scripts;
using UnityEngine;

namespace Interfaces
{
    public interface IBuffable
    {
        void AddBuff(GameObject player);
        void RemoveBuff();
    }
}
