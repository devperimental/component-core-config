namespace PlatformX.Common.Types.DataContract
{
    public class BootstrapConfiguration
    {
        public string EnvironmentName { get; set; }
        public string AspNetCoreEnvironmentName { get; set; }
        public string Prefix { get; set; }
        public string RoleKey { get; set; }
        public string PortalName { get; set; }
        public string ServiceName { get; set; }
        public string Layer { get; set; }
        public string AzureRegion { get; set; }
        public string AzureLocation { get; set; }
        public string AzureTenantId { get; set; }
        public string AwsRegion { get; set; }
        public string SsmPrefix { get; set; }
        public string ServiceKeys { get; set; }
        public string RuntimeConfiguration { get; set; }
        public string ServiceSymmetricKeyName { get; set; }
        public string HostEnvironmentType { get; set; }
        public string CorsOrigins { get; set; }
    }
}