using DotNetEnv.Configuration;

namespace InfoKeeper.Presentation.Api.Extensions;

public static class ConfigurationManagerExtensions
{
    public static void AddEnvFiles(this ConfigurationManager configuration, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            configuration.AddDotNetEnv("./dev.env");
        } else if (environment.IsProduction())
        {
            configuration.AddDotNetEnv("./prod.env");
        }
    }
}