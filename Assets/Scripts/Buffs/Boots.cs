namespace Buffs
{
    public class Boots : LootBuffs
    {
        private const float Acceleration = 1.6f;

        public override void AddBuff() => Movement.SetSpeed(Acceleration);

        public override void RemoveBuff() => Movement.ResetSpeed(Acceleration);
    }
}