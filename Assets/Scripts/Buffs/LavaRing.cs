using UnityEngine.UI;

namespace Buffs
{
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;
        
        public override Image GetImage() => GetComponent<Image>();
    }
}