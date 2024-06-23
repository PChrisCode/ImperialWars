namespace ImperialWars.Core.Settings
{
    public interface IResourceRequirement
    {
        long Wood { get; }
        long Clay { get; }
        long Iron { get; }
        long Population { get; }
    }
}
