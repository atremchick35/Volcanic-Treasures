using UnityEngine;

namespace Buffs
{
    public class Immortality : LootBuffs
    {
        private bool _isClaimed;
    
        protected override void AddBuff()
        {
            if (!_isClaimed)
            {
                Player.IsImmortal = true;
                _isClaimed = true;
            }
        }

        protected override void RemoveBuff()
        {
            if (_isClaimed)
            {
                Player.IsImmortal = false;
                _isClaimed = false;
            }
        }

        protected override Transform GetTransform() => 
            Canvas.transform.GetChild(Fields.Buffs.PanelIndex).GetChild(Fields.Buffs.ImmortalityIconIndex);
    }
}
