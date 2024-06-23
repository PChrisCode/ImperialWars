using ImperialWars.Core.Battle;
using ImperialWars.Core.Settings;

namespace ImperialWars.Core
{
    internal class UnitFactory : IUnitFactory
    {
        private readonly IApplicationSettings _applicationSettings;

        public UnitFactory(IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings ?? throw new ArgumentNullException(nameof(applicationSettings));
        }

        public IUnit CreateUnit(string id)
        {
            foreach (var unitDefinition in _applicationSettings.UnitDefinitions)
            {
                if (string.Equals(unitDefinition.Key, id, StringComparison.Ordinal))
                {
                    var resourceRequirement = new UnitResourceRequirement(unitDefinition.ResourceRequirement.Wood,
                        unitDefinition.ResourceRequirement.Clay,
                        unitDefinition.ResourceRequirement.Iron,
                        unitDefinition.ResourceRequirement.Population);

                    var battleModifiers = new List<IBattleModifier>(); // TODO: implement

                    return new Unit(resourceRequirement, unitDefinition.OffensiveStrength, unitDefinition.DefensiveStrength,
                        unitDefinition.Speed, unitDefinition.Booty, battleModifiers);
                }
            }

            throw new NotSupportedException($"Unit \"{id}\" is not supported.");
        }
    }
}
