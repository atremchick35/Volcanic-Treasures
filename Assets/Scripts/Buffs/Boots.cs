using UnityEngine;

namespace Buffs
{
    // Реализация "ботинок"
    public class Boots : LootBuffs
    {
        protected override void AddBuff() => Movement.SetSpeed(Fields.Buffs.BootsAcceleration);

        protected override void RemoveBuff() => Movement.ResetSpeed(Fields.Buffs.BootsAcceleration);
        
        protected override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(0);
    }
}