using UnityEngine;

namespace Buffs
{
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;

        public override Transform GetImage()
        {
            Debug.Log("LavaRing weared");
            return Canvas.transform.GetChild(0).GetChild(2);
        }
    }
}