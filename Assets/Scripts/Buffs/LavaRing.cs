using UnityEngine;
using UnityEngine.UI;

namespace Buffs
{
    // Реализация "защиты"
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;
        
        public override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(2);
    }
}