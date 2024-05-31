using UnityEngine;

namespace Buffs
{
    // Реализация "защиты"
    public class LavaRing : LootBuffs
    {
        protected override void AddBuff() => Player.HasRingLava = true;

        protected override void RemoveBuff() => Player.HasRingLava = false;
        
        protected override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(2);
    }
}