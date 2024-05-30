using UnityEngine;

namespace Buffs
{
    public class Helmet : LootBuffs
    {
        public override void AddBuff() => Player.HasHelmet = true;

        public override void RemoveBuff() => Player.HasHelmet = false;

        public override Transform GetImage()
        {
            Debug.Log("Helmet claimed");
            return Canvas.transform.GetChild(0).GetChild(1);
        }
    }
}