namespace ImperialWars.Core.Settings
{
    public interface IApplicationSettings
    {
        IEnumerable<IUnitDefinition> UnitDefinitions { get; }
    }
}
