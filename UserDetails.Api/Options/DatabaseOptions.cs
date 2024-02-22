namespace UserDetails.Api.Options
{
    public class DatabaseOptions
    {
        public string ConnectionStrings { get; set; } = string.Empty;
        public int MaxRetryCount { get; set; }
        public int CommandTimeout { get; set; }
        public bool EnableDetailedError { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
    }
}
