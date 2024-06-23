using ImperialWars.Core.Battle;

namespace ImperialWars.Core
{
    public interface IUnit
    {
        long Health { get; }
        bool IsDead { get; }
        IUnitResourceRequirement ResourceRequirement { get; }
        long OffensiveStrength { get; }
        long DefensiveStrength { get; }
        long Speed { get; }
        long Booty { get; }
        IEnumerable<IBattleModifier> BattleModifiers { get; }

        IUnit FindTarget(IBattleground battleground);
        void AttackTarget(IUnit target);
        void Hit(long damagePoint);
    }
}
