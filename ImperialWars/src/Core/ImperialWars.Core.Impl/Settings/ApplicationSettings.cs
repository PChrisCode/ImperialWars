namespace ImperialWars.Core.Settings
{
    public class ApplicationSettings : IApplicationSettings
    {
        IEnumerable<IUnitDefinition> IApplicationSettings.UnitDefinitions => UnitDefinitions;
        public IEnumerable<UnitDefinition> UnitDefinitions { get; set; }
    }
}
