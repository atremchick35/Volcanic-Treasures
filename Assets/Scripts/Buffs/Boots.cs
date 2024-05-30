using UnityEngine;

namespace Buffs
{
    public class Boots : LootBuffs
    {
        private const float Acceleration = 1.6f;
        
        public override void AddBuff() => Movement.SetSpeed(Acceleration);

        public override void RemoveBuff() => Movement.ResetSpeed(Acceleration);

        public override Transform GetImage()
        {
            Debug.Log("Speed accelerated");
            return Canvas.transform.GetChild(0).GetChild(0);
        }
    }
}