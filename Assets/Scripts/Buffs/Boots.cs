using UnityEngine;

namespace Buffs
{
    // Реализация "ботинок"
    public class Boots : LootBuffs
    {
        private const float Acceleration = 1.6f;

        protected override void AddBuff() => Movement.SetSpeed(Acceleration);

        protected override void RemoveBuff() => Movement.ResetSpeed(Acceleration);
        
        protected override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(0);
    }
}