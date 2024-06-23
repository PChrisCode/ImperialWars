namespace ImperialWars.Core.Battle
{
    public interface IBattleground
    {
        IEnumerable<IUnit> OffensiveArmy { get; }
        IEnumerable<IUnit> DeffensiveArmy { get; }
    }
}
