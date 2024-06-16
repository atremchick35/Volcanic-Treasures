using UnityEngine;

namespace Buffs
{
    // Реализация "ботинок"
    public class Boots : LootBuffs
    {
        private bool _isClaimed;
        
        protected override void AddBuff()
        {
            if (!_isClaimed)
            {
                Movement.SetSpeed(Fields.Buffs.BootsAcceleration);
                _isClaimed = true;
            }
        }

        protected override void RemoveBuff()
        {
            Movement.ResetSpeed(Fields.Buffs.BootsAcceleration);
            _isClaimed = false;
        }
        
        protected override Transform GetTransform() => 
            Canvas.transform.GetChild(Fields.Buffs.PanelIndex).GetChild(Fields.Buffs.BootsIconIndex);
    }
}