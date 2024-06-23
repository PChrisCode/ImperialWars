namespace ImperialWars.Core
{
    internal class UnitResourceRequirement : IUnitResourceRequirement
    {
        public long Wood { get; }
        public long Clay { get; }
        public long Iron { get; }
        public long Population { get; }

        public UnitResourceRequirement(long wood, long clay, long iron, long population)
        {
            Wood = wood;
            Clay = clay;
            Iron = iron;
            Population = population;
        }
    }
}
