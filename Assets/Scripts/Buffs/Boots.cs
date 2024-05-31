<<<<<<< HEAD
=======
using UnityEngine;

>>>>>>> Artem_branch
namespace Buffs
{
    // Реализация "ботинок"
    public class Boots : LootBuffs
    {
        private const float Acceleration = 1.6f;

        public override void AddBuff() => Movement.SetSpeed(Acceleration);

        public override void RemoveBuff() => Movement.ResetSpeed(Acceleration);
<<<<<<< HEAD
=======

        public override Transform GetImage()
        {
            Debug.Log("Speed accelerated");
            return Canvas.transform.GetChild(0).GetChild(0);
        }
>>>>>>> Artem_branch
    }
}