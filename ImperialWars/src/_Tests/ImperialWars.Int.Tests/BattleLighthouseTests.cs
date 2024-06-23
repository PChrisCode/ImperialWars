using ImperialWars.Core;
using ImperialWars.Core.Core;
using ImperialWars.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImperialWars.Int.Tests
{
    public class BattleLighthouseTests
    {
        // https://help.tribalwars.net/wiki/Units
        // https://www.plantuml.com/plantuml/uml/SoWkIImgAStDuShCAqajIajCJbNmz4tCpFFDJodDILMevghbGfPoB2Z8oKnEBCdCpmjEBId9p4ilnb0JcfTPWbNGBJ6v9B-e4YYdeA2ju5oKcbYI2XBNqDFJqxI2g05fGr6igsi7aS4GnkeQBYJNG_KYT75nEQJcfG1z2m00
        // https://www.plantuml.com/plantuml/uml/SoWkIImgAStDuV9DpCpppKyfpKbLqBLJy0pDoonnIqmkoI-gLB1IS2vAJIn91Obf59SKPUQbAsIcQ78XAm9hSYmeoCbCJYp9pCyBJYqf0Qeh1cfsJot18g61gH_C1se02G2b7LBpKe0k0m00

        [Fact]
        public void BLT0011_UnitCanAttackOtherUnit_When_CorrectlyInitialized()
        {
            var modules = InitializeModules();

            using (var scope = modules.CreateScope())
            {
                var unitFactory = scope.ServiceProvider.GetRequiredService<IUnitFactory>();
                var spearFighter = unitFactory.CreateUnit(Constants.Units.SpearFighterId);
                var swordsman = unitFactory.CreateUnit(Constants.Units.SwordsmanId);

                spearFighter.AttackTarget(swordsman);
            }
        }

        private static void InitializeAppSettings(IApplicationSettings applicationSettings, IServiceCollection serviceCollection)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            configBuilder.Bind("ApplicationSettings", applicationSettings);

            serviceCollection.AddSingleton(applicationSettings);
            //return configBuilder.GetRequiredSection("ApplicationSettings").Get<IApplicationSettings>((o) => o.) ?? throw new InvalidOperationException("Application settings is not correctly defined.");
        }

        private static IServiceProvider InitializeModules()
        {
            var serviceCollection = new ServiceCollection();

            _ = new ImperialWarsModule(serviceCollection);

            InitializeAppSettings(new ApplicationSettings(), serviceCollection);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
