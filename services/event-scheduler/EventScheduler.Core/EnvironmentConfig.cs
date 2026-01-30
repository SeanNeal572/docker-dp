using Microsoft.Extensions.Configuration;

namespace EventScheduler.Core
{
    public class EnvironmentConfig
    {
        public static readonly string Env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
        public static readonly IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{Env}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        private class DbConfigException(string value) : Exception("Missing db config value: " + value) { }

        private static readonly IConfigurationSection DbConfiguration = Configuration.GetSection("Db");
        public static readonly string DbProvider = DbConfiguration["Provider"] ?? throw new DbConfigException("Provider");
        public static readonly string DbHost = DbConfiguration["Host"] ?? throw new DbConfigException("Host");
        public static readonly string DbPort = DbProvider switch
        {
            "postgres" => DbConfiguration["PortPostgres"] ?? throw new DbConfigException("PortPostgres"),
            "mssql-dp" => DbConfiguration["PortMssql"] ?? throw new DbConfigException("PortMssql"),
            _ => throw new Exception("Invalid database provider")
        };
        public static readonly string DbUser = DbConfiguration["User"] ?? throw new DbConfigException("User");
        public static readonly string DbPassword = DbConfiguration["Password"] ?? throw new DbConfigException("Password");
        public static readonly string DbDatabase = DbConfiguration["Database"] ?? throw new DbConfigException("Database");
    }
}
