<<<<<<< HEAD
=======
using UnityEngine;

>>>>>>> Artem_branch
namespace Buffs
{
    // Реализация "защиты"
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;
<<<<<<< HEAD
=======

        public override Transform GetImage()
        {
            Debug.Log("LavaRing weared");
            return Canvas.transform.GetChild(0).GetChild(2);
        }
>>>>>>> Artem_branch
    }
}