namespace ImperialWars.Core.Battle
{
    public interface IBattleModifier
    {
        decimal CalculateDamagePoint(IUnit unit);
        decimal CalculateDefensePoint(IUnit unit);
        decimal CalculateHitChance(IUnit attacker, IUnit defender);
        decimal CalculateDefendChance(IUnit attacker, IUnit defender);
    }
}
