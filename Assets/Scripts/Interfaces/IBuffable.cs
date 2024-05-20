using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interfaces
{
    public interface IBuffable
    {
        void AddBuff(GameObject player);
        void RemoveBuff();
    }
}
