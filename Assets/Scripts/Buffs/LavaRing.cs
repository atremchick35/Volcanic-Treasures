<<<<<<< HEAD
=======
using UnityEngine;
using UnityEngine.UI;

>>>>>>> parent of 7856ced (Add_Menu_Pause)
namespace Buffs
{
    // Реализация "защиты"
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;
<<<<<<< HEAD
=======
        
        public override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(2);
>>>>>>> parent of 7856ced (Add_Menu_Pause)
    }
}