using ImperialWars.Core.Battle;

namespace ImperialWars.Core
{
    internal class Unit : IUnit
    {
        public long Health { get; private set; }
        public bool IsDead => Health < 1;
        public IUnitResourceRequirement ResourceRequirement { get; }
        public long OffensiveStrength { get; }
        public long DefensiveStrength { get; }
        public long Speed { get; }
        public long Booty { get; }
        public IEnumerable<IBattleModifier> BattleModifiers { get; }

        public Unit(
            IUnitResourceRequirement resourceRequirement,
            long offensiveStrength,
            long defensiveStrength,
            long speed,
            long booty,
            IEnumerable<IBattleModifier> battleModifiers)
        {
            ResourceRequirement = resourceRequirement ?? throw new ArgumentNullException(nameof(resourceRequirement));
            OffensiveStrength = offensiveStrength;
            DefensiveStrength = defensiveStrength;
            Speed = speed;
            Booty = booty;
            Health = 100;

            BattleModifiers = battleModifiers ?? throw new ArgumentNullException(nameof(battleModifiers));
        }

        public void AttackTarget(IUnit target)
        {
            var attackerDamagePoint = 0M;
            var attackerDefensePoint = 0M;
            var attackerHitChance = 0M;
            var attackerDefendChance = 0M;

            var defenderDamagePoint = 0M;
            var defenderDefensePoint = 0M;
            var defenderHitChance = 0M;
            var defenderDefendChance = 0M;

            foreach (var modifier in BattleModifiers)
            {
                attackerDamagePoint += modifier.CalculateDamagePoint(this);
                attackerDefensePoint += modifier.CalculateDefensePoint(this);
                attackerHitChance += modifier.CalculateHitChance(this, target);
                attackerDefendChance += modifier.CalculateDefendChance(this, target);
            }

            foreach (var modifier in target.BattleModifiers)
            {
                defenderDamagePoint += modifier.CalculateDamagePoint(target);
                defenderDefensePoint += modifier.CalculateDefensePoint(target);
                defenderHitChance += modifier.CalculateHitChance(target, this);
                defenderDefendChance += modifier.CalculateDefendChance(target, this);
            }

            attackerDamagePoint = ModifyDamagePointWithDefensePoint(attackerDamagePoint, defenderDefensePoint);
            defenderDamagePoint = ModifyDamagePointWithDefensePoint(defenderDamagePoint, attackerDefensePoint);

            var attackerDamageModifier = decimal.ToInt64(attackerDamagePoint);
            var defenderDamageModifier = decimal.ToInt64(defenderDamagePoint);

            if (attackerHitChance > defenderDefendChance)
            {
                target.Hit(attackerDamageModifier);
            }

            if (!target.IsDead && defenderHitChance > attackerDefendChance)
            {
                Hit(defenderDamageModifier);
            }
        }

        public IUnit FindTarget(IBattleground battleground)
        {
            foreach (var unit in battleground.DeffensiveArmy)
            {
                if (!unit.IsDead)
                {

                }
            }

            throw new NotImplementedException();
        }

        public void Hit(long damagePoint)
        {
            Health -= damagePoint;
        }

        private static decimal ModifyDamagePointWithDefensePoint(decimal damagePoints, decimal defensePoint)
        {
            // TODO: atgondolni
            if (damagePoints < defensePoint)
            {
                return defensePoint / damagePoints;
            }

            return damagePoints - defensePoint;
        }
    }
}
