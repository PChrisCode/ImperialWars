namespace ImperialWars.Core.Settings
{
    public interface IUnitDefinition
    {
        string Key { get; }
        IResourceRequirement ResourceRequirement { get; }
        long OffensiveStrength { get; }
        long DefensiveStrength { get; }
        long Speed { get; }
        long Booty { get; }
    }
}
