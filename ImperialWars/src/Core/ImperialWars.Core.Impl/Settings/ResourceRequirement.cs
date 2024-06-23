namespace ImperialWars.Core.Settings
{
    public class ResourceRequirement : IResourceRequirement
    {
        public long Wood { get; set; }
        public long Clay { get; set; }
        public long Iron { get; set; }
        public long Population { get; set; }
    }
}
