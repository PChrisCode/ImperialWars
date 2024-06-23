using Microsoft.Extensions.DependencyInjection;

namespace ImperialWars.Core.Core
{
    public class ImperialWarsModule
    {
        public ImperialWarsModule(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUnitFactory, UnitFactory>();
        }
    }
}
