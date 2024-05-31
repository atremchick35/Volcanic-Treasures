<<<<<<< HEAD
=======
using UnityEngine;
using UnityEngine.UI;

>>>>>>> parent of 7856ced (Add_Menu_Pause)
namespace Buffs
{
    // Реализация "шлема"
    public class Helmet : LootBuffs
    {
        public override void AddBuff() => Player.HasHelmet = true;

        public override void RemoveBuff() => Player.HasHelmet = false;
<<<<<<< HEAD
=======
        
        public override Transform GetImage() => Canvas.transform.GetChild(0).GetChild(1);
>>>>>>> parent of 7856ced (Add_Menu_Pause)
    }
}