using FluentValidation.AspNetCore;
using Presentation.Filters;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();


        services.AddHttpContextAccessor();


        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

        services.AddRazorPages();
        services.AddCors();


        return services;
    }
}
