namespace Buffs
{
    public class LavaRing : LootBuffs
    {
        public override void AddBuff() => Player.HasRingLava = true;

        public override void RemoveBuff() => Player.HasRingLava = false;
    }
}