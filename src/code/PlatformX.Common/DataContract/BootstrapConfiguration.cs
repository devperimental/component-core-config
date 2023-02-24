namespace PlatformX.Common.Types.DataContract
{
    public class BootstrapConfiguration
    {
        public string Prefix { get; set; }
        public string RoleKey { get; set; }
        public string Environment { get; set; }
        public string Region { get; set; }
        public string Location { get; set; }
        public string PortalName { get; set; }
        public string Layer { get; set; }
        public bool LogMessages { get; set; }
        public bool LogWarnings { get; set; }
        public bool LogErrors { get; set; }
        public string DBName { get; set; }
        public string PlatformServiceMetaData { get; set; }
        public string ServiceKeys { get; set; }
        public string RuntimeConfiguration { get; set; }
        public string TenantId { get; set; }
        public string ServiceSymmetricKeyName { get; set; }
        public string ServerName { get; set; }
        public string BuildNumber { get; set; }
        public string ContainerType { get; set; }
    }
}