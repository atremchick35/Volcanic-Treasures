using UnityEngine;

namespace Buffs
{
    // Реализация "шлема"
    public class Helmet : LootBuffs
    {
        public override void AddBuff() => Player.HasHelmet = true;

        public override void RemoveBuff() => Player.HasHelmet = false;
        
        public override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(1);
    }
}