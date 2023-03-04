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

        #region Azure Environment
        public string AzureRegion { get; set; }
        public string AzureLocation { get; set; }
        public string AzureTenantId { get; set; }
        #endregion

        #region AWS Environment
        public string AwsRegion { get; set; }
        public string SsmPrefx { get; set; }
        #endregion
        
        #region Logging
        public bool LogMessages { get; set; }
        public bool LogWarnings { get; set; }
        public bool LogErrors { get; set; }
        #endregion
        public string DBName { get; set; }
        public string PlatformServiceMetaData { get; set; }
        public string ServiceKeys { get; set; }
        public string RuntimeConfiguration { get; set; }
        public string ServiceSymmetricKeyName { get; set; }
        public string ServerName { get; set; }
        public string BuildNumber { get; set; }
        public string ContainerType { get; set; }
        public string CorsOrigins { get; set; }
    }
}