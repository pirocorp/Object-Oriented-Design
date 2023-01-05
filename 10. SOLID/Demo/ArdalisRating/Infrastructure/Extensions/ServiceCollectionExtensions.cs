namespace ArdalisRating.Infrastructure.Extensions;

using ArdalisRating.Core;
using ArdalisRating.Core.Interfaces;
using ArdalisRating.Core.PolicyRaters;
using ArdalisRating.Infrastructure.Loggers;
using ArdalisRating.Infrastructure.PolicySources;
using ArdalisRating.Infrastructure.Serializers;

using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterDependencies(this IServiceCollection services)
    {
        services
            .AddTransient<ILogger, ConsoleLogger>()
            .AddTransient<IPolicySource, FilePolicySource>()
            .AddTransient<IPolicySerializer, JsonPolicySerializer>()
            .AddTransient<RaterFactory>()
            .AddTransient<RatingEngine>();

        return services;
    }
}
