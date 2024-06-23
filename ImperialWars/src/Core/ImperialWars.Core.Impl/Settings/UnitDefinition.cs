namespace ImperialWars.Core.Settings
{
    public class UnitDefinition : IUnitDefinition
    {
        public string Key { get; set; }
        IResourceRequirement IUnitDefinition.ResourceRequirement => ResourceRequirement;
        public ResourceRequirement ResourceRequirement { get; set; }
        public long OffensiveStrength { get; set; }
        public long DefensiveStrength { get; set; }
        public long Speed { get; set; }
        public long Booty { get; set; }

        public UnitDefinition()
        {
            Key = string.Empty;
            ResourceRequirement = new ResourceRequirement();
        }
    }
}
