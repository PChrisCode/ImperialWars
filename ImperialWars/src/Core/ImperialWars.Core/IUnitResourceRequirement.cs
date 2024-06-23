namespace ImperialWars.Core
{
    public interface IUnitResourceRequirement
    {
        long Wood { get; }
        long Clay { get; }
        long Iron { get; }
        long Population { get; }
    }
}
