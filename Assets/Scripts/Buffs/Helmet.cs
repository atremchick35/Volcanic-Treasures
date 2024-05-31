using UnityEngine;

namespace Buffs
{
    // Реализация "шлема"
    public class Helmet : LootBuffs
    {
        protected override void AddBuff() => Player.HasHelmet = true;

        protected override void RemoveBuff() => Player.HasHelmet = false;
        
        protected override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(1);
    }
}